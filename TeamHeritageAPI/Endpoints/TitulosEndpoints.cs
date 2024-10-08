using TeamHeritageAPI.Requests;
using TeamHeritageAPI.Responses;
using TeamHeritageShared.Models;
using TeamHeritageAPI.Banco;


public static class TitulosEndpoints
{
    public static void MapTitulosEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/time/ListaDeTitulos", async (IRepository<Titulo> repository) =>
        {
            var titulos = await repository.GetAllAsync();
            return Results.Ok(titulos);
        });

        app.MapGet("/titulo/{nome}", async (IRepository<Titulo> repository, string nome) =>
        {
            var titulos = await repository.BuscaPorAsync(t => t.Nome.ToUpper().Contains(nome.ToUpper()));
            if (titulos is not null)
            {
                return Results.Ok(titulos);
            }
            else
            {
                return Results.NotFound("Nenhum título encontrado com esse nome.");
            }
        });

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
        app.MapPut("/titulo/{tituloId}", async (IRepository<Titulo> repository, int tituloId, TituloRequestEdit tituloRequestEdit) =>
        {
            var titulo = await repository.BuscaPorAsync(t => t.Id.Equals(tituloId));
            if (titulo is null)
            {
                return Results.NotFound("Nenhum título encontrado com esse id.");
            }
            titulo.Nome = tituloRequestEdit.Nome;
            titulo.Ano = tituloRequestEdit.Ano;
            return Results.Ok(titulo);
        });
    }
}
