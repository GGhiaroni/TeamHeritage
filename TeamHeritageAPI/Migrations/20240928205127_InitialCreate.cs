using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamHeritageAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    TimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estadio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTorcedores = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EscudoOficial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.TimeId);
                });

            migrationBuilder.CreateTable(
                name: "Titulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    TimeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Titulos_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "TimeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Titulos_TimeId",
                table: "Titulos",
                column: "TimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Titulos");

            migrationBuilder.DropTable(
                name: "Times");
        }
    }
}
