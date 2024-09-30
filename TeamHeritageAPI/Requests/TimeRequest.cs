namespace TeamHeritageAPI.Requests
{
    public record TimeRequest(string nome, string cidade, string pais, string? estadio = null,
                          int? numeroTorcedores = null, string? descricao = null, string? escudoOficial = null);
}