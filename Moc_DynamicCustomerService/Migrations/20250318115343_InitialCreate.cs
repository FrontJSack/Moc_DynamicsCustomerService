using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moc_DynamicCustomerService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Konta",
                columns: table => new
                {
                    kontoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nazwaFirmy = table.Column<string>(type: "TEXT", nullable: false),
                    branza = table.Column<string>(type: "TEXT", nullable: false),
                    nip = table.Column<string>(type: "TEXT", nullable: false),
                    adres = table.Column<string>(type: "TEXT", nullable: false),
                    miasto = table.Column<string>(type: "TEXT", nullable: false),
                    kraj = table.Column<string>(type: "TEXT", nullable: false),
                    emailGlowny = table.Column<string>(type: "TEXT", nullable: false),
                    telefonGlowny = table.Column<string>(type: "TEXT", nullable: false),
                    dataUtworzenia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dataModyfikacji = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konta", x => x.kontoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Konta");
        }
    }
}
