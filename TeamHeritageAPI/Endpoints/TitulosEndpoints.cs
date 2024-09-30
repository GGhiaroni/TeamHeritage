using TeamHeritageAPI.Requests;
using TeamHeritageAPI.Responses;
using TeamHeritageShared.Models;

public static class TitulosEndpoints
{
    public static void MapTitulosEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/time/{timeId:int}/AdicionarTitulo", async (IRepository<Time> repository, int timeId, TituloRequest tituloRequest) =>
        {
            var timeExistente = await repository.GetByIdAsync(timeId);
            if (timeExistente is null) return Results.NotFound("Time não encontrado.");

            var tituloJaExiste = timeExistente.Titulos != null && timeExistente.Titulos.Any(
            t => t.Nome == tituloRequest.Nome && t.Ano == tituloRequest.Ano
        );

            if (tituloJaExiste)
            {
                return Results.Conflict("Título já cadastrado para esse time.");
            }

            Titulo novoTitulo = new Titulo(tituloRequest.Nome, tituloRequest.Ano);
            timeExistente.Titulos ??= new List<Titulo>(); // Inicializa a lista se for nula
            timeExistente.Titulos.Add(novoTitulo);

            await repository.UpdateAsync(timeExistente);

            return Results.Ok(timeExistente);
        });
    }
}
