
using TeamHeritageShared.Models;

namespace TeamHeritageAPI.Responses
{
    public record TimeResponse(string nome, string cidade, string pais, string? estadio = null,
                          int? numeroTorcedores = null, string? descricao = null, string? escudoOficial = null, ICollection<Titulo>? titulos = null);
}