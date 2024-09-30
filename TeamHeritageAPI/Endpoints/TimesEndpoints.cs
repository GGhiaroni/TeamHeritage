using TeamHeritageAPI.Requests;
using TeamHeritageShared.Models;

public static class TimesEndpoints
{
    public static void MapTimesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/Times", async (IRepository<Time> repository) =>
        {
            var times = await repository.GetAllAsync();
            return Results.Ok(times);
        });

        app.MapPost("/CadastrarTime", async (IRepository<Time> repository, TimeRequest timeRequest) =>
        {
            Time novoTime = new Time(
                timeRequest.nome,
                timeRequest.cidade,
                timeRequest.pais,
                timeRequest.estadio,
                timeRequest.numeroTorcedores,
                timeRequest.descricao,
                timeRequest.escudoOficial
            );

            await repository.AddAsync(novoTime);
            return Results.Created($"/times/{novoTime.TimeId}", novoTime);
        });

        app.MapGet("/times/{id:int}", async (IRepository<Time> repository, int id) =>
        {
            var time = await repository.GetByIdAsync(id);
            return time != null ? Results.Ok(time) : Results.NotFound();
        });

        app.MapPut("/times/{id:int}", async (IRepository<Time> repository, int id, Time timeAtualizado) =>
        {
            var timeExistente = await repository.GetByIdAsync(id);
            if (timeExistente is null) return Results.NotFound();

            timeExistente.Nome = timeAtualizado.Nome;
            timeExistente.Cidade = timeAtualizado.Cidade;
            timeExistente.Pais = timeAtualizado.Pais;
            timeExistente.Estadio = timeAtualizado.Estadio;
            timeExistente.NumeroTorcedores = timeAtualizado.NumeroTorcedores;
            timeExistente.Descricao = timeAtualizado.Descricao;
            timeExistente.EscudoOficial = timeAtualizado.EscudoOficial;

            await repository.UpdateAsync(timeExistente);
            return Results.Ok(timeAtualizado);
        });

        app.MapDelete("/times/{id:int}", async (IRepository<Time> repository, int id) =>
        {
            var time = await repository.GetByIdAsync(id);
            if (time is null) return Results.NotFound();

            await repository.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}
