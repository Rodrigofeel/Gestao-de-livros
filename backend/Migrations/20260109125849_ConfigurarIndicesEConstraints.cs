using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestãoDeLivros.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurarIndicesEConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Categoria = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Autor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Editora = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AnoPublicado = table.Column<int>(type: "integer", nullable: false),
                    NumeroPaginas = table.Column<int>(type: "integer", nullable: false),
                    ISBN = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: false),
                    Resumo = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_Autor",
                table: "Livros",
                column: "Autor");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_Categoria",
                table: "Livros",
                column: "Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_ISBN",
                table: "Livros",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_Titulo",
                table: "Livros",
                column: "Titulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
