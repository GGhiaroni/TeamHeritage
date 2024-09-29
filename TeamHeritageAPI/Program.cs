using TeamHeritageAPI.Banco;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar a conexão com o SQL Server
builder.Services.AddDbContext<TeamHeritageDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TeamHeritageDB")));

// Outros serviços
builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<>), typeof(DAL<>));

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Usar Swagger apenas em ambientes de desenvolvimento (opcional)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Team Heritage API V1");
        c.RoutePrefix = string.Empty; // Isso torna o Swagger disponível diretamente na raiz "/"
    });
}

// Configurar os middlewares
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.MapTimesEndpoints();

app.Run();
