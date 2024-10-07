using System.Text.Json.Serialization;

namespace TeamHeritageShared.Models
{
    public class Titulo
    {
        public Titulo(string nome, int ano)
        {
            Nome = nome;
            Ano = ano;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public int TimeId { get; set; }

        [JsonIgnore]
        public Time? Time { get; set; }
    }
}