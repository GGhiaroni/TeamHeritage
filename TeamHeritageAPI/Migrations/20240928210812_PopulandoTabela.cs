using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamHeritageAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeId", "Nome", "Cidade", "Pais", "Estadio", "NumeroTorcedores", "Descricao", "EscudoOficial" },
                values: new object[,]
                {
                    { 1, "Barcelona", "Barcelona", "Espanha", "Camp Nou", 98000000, "Um dos maiores clubes da Europa, conhecido por seu estilo de jogo ofensivo.", "url_do_escudo_barcelona" },
                    { 2, "Real Madrid", "Madrid", "Espanha", "Santiago Bernabéu", 100000000, "Clube histórico, com mais títulos de Liga dos Campeões da UEFA.", "url_do_escudo_real_madrid" },
                    { 3, "Roma", "Roma", "Itália", "Estádio Olímpico", 10000000, "A AS Roma é um dos clubes mais históricos da Itália, com forte tradição e grandes torcedores na capital italiana.", "url_do_escudo_roma" },
                    { 4, "Porto", "Porto", "Portugal", "Estádio do Dragão", 8000000, "O FC Porto é um gigante do futebol português, conhecido por sua competitividade e conquistas internacionais.", "url_do_escudo_porto" },
                    { 5, "Juventus", "Turim", "Itália", "Allianz Stadium", 110000000, "A Juventus é o clube mais vitorioso da Itália, com um legado de sucesso e uma base global de torcedores.", "url_do_escudo_juventus" },
                    { 6, "Inter de Milão", "Milão", "Itália", "San Siro", 70000000, "A Inter de Milão é uma das maiores potências do futebol italiano, com conquistas significativas tanto na Itália quanto na Europa.", "url_do_escudo_inter" },
                    { 7, "Milan", "Milão", "Itália", "San Siro", 95000000, "O AC Milan é um dos clubes mais bem-sucedidos do mundo, especialmente conhecido por seus títulos na Liga dos Campeões da UEFA.", "url_do_escudo_milan" },
                    { 8, "Chelsea", "Londres", "Inglaterra", "Stamford Bridge", 75000000, "O Chelsea se tornou uma potência no futebol inglês nas últimas décadas, com grandes conquistas na Premier League e na Europa.", "url_do_escudo_chelsea" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover dados se necessário
            migrationBuilder.DeleteData(table: "Times", keyColumn: "TimeId", keyValues: new object[] { 1 });
            migrationBuilder.DeleteData(table: "Times", keyColumn: "TimeId", keyValues: new object[] { 2 });
            migrationBuilder.DeleteData(table: "Times", keyColumn: "TimeId", keyValues: new object[] { 3 });
            migrationBuilder.DeleteData(table: "Times", keyColumn: "TimeId", keyValues: new object[] { 4 });
            migrationBuilder.DeleteData(table: "Times", keyColumn: "TimeId", keyValues: new object[] { 5 });
            migrationBuilder.DeleteData(table: "Times", keyColumn: "TimeId", keyValues: new object[] { 6 });
            migrationBuilder.DeleteData(table: "Times", keyColumn: "TimeId", keyValues: new object[] { 7 });
            migrationBuilder.DeleteData(table: "Times", keyColumn: "TimeId", keyValues: new object[] { 8 });
        }
    }
}
