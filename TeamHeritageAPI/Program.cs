using TeamHeritageAPI.Banco;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar a conexão com o SQL Server
builder.Services.AddDbContext<TeamHeritageDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TeamHeritageDB")));

// Outros serviços
builder.Services.AddControllers();

builder.Services.AddScoped(typeof(IRepository<>), typeof(DAL<>));

var app = builder.Build();

app.MapTimesEndpoints();

// Configurar os middlewares
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
