using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moc_DynamicCustomerService.Migrations
{
    /// <inheritdoc />
    public partial class kontaktyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontakty",
                columns: table => new
                {
                    kontaktId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    kontoId = table.Column<int>(type: "INTEGER", nullable: false),
                    imie = table.Column<string>(type: "TEXT", nullable: false),
                    nazwisko = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    telefon = table.Column<string>(type: "TEXT", nullable: false),
                    data_utworzenia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    data_modyfikacji = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakty", x => x.kontaktId);
                    table.ForeignKey(
                        name: "FK_Kontakty_Konta_kontoId",
                        column: x => x.kontoId,
                        principalTable: "Konta",
                        principalColumn: "kontoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kontakty_kontoId",
                table: "Kontakty",
                column: "kontoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kontakty");
        }
    }
}
