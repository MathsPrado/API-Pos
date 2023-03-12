using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.API.Migrations
{
    /// <inheritdoc />
    public partial class T : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropostaSolicitacaoProjeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descircao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempoEntrega = table.Column<int>(type: "int", nullable: false),
                    Orçamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPropostaSolucao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropostaSolicitacaoProjeto", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropostaSolicitacaoProjeto");
        }
    }
}
