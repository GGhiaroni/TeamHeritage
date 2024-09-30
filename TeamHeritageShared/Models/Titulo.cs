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
    }
}