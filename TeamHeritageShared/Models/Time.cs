using TeamHeritageShared.Models;

namespace TeamHeritageShared.Models
{
    public class Time
    {
        public Time(string nome, string cidade, string pais, string? estadio = null, int? numeroTorcedores = null,
                    string? descricao = null, string? escudoOficial = null)
        {
            Nome = nome;
            Cidade = cidade;
            Pais = pais;
            Estadio = estadio ?? string.Empty;
            NumeroTorcedores = numeroTorcedores;
            Descricao = descricao ?? string.Empty;
            EscudoOficial = escudoOficial ?? string.Empty;
        }

        public int TimeId { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
        public string? Estadio { get; set; }
        public int? NumeroTorcedores { get; set; }
        public string? Descricao { get; set; }
        public string? EscudoOficial { get; set; }
        public ICollection<Titulo>? Titulos { get; set; } = new List<Titulo>();
    }
}