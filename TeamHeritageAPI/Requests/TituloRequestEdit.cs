namespace TeamHeritageAPI.Requests
{
    public record TituloRequestEdit(int Id, string Nome, int Ano) : TituloRequest(Nome, Ano);
}