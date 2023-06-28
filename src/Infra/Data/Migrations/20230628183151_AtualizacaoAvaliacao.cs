using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biopark.CpaSurvey.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoAvaliacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvaliacaoTurma",
                columns: table => new
                {
                    AvaliacoesId = table.Column<long>(type: "bigint", nullable: false),
                    TurmasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoTurma", x => new { x.AvaliacoesId, x.TurmasId });
                    table.ForeignKey(
                        name: "FK_AvaliacaoTurma_Avaliacao_AvaliacoesId",
                        column: x => x.AvaliacoesId,
                        principalTable: "Avaliacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvaliacaoTurma_Turma_TurmasId",
                        column: x => x.TurmasId,
                        principalTable: "Turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoTurma_TurmasId",
                table: "AvaliacaoTurma",
                column: "TurmasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoTurma");
        }
    }
}
