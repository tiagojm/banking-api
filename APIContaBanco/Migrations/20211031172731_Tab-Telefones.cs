using Microsoft.EntityFrameworkCore.Migrations;

namespace APIContaBanco.Migrations
{
    public partial class TabTelefones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelefonesContato",
                columns: table => new
                {
                    ClienteId = table.Column<long>(type: "bigint", nullable: true),
                    TipoTelefone = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TelefonesContato_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonesContato_ClienteId",
                table: "TelefonesContato",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelefonesContato");
        }
    }
}
