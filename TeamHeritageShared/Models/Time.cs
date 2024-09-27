using TeamHeritageShared.Models;

namespace TeamHeritageShared.Models
{
    public class Time
    {
        public int TimeId { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
        public string Estadio { get; set; }
        public ICollection<Titulo> Titulos { get; set; }
        public int NumeroTorcedores { get; set; }
        public string Descricao { get; set; }
        public string EscudoOficial { get; set; }
    }
}