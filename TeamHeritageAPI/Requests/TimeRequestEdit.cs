namespace TeamHeritageAPI.Requests;

public record TimeRequestEdit(int Id, string Nome, string Cidade, string Pais, string? Estadio,
                         int? NumeroTorcedores, string? Descricao, string? EscudoOficial)
                         : TimeRequest(Nome, Cidade, Pais, Estadio, NumeroTorcedores, Descricao, EscudoOficial);