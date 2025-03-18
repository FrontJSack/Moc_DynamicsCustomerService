using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moc_DynamicCustomerService.Migrations
{
    /// <inheritdoc />
    public partial class umowaModelpatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UmowySla",
                columns: table => new
                {
                    umowa_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    kontoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false),
                    Opis = table.Column<string>(type: "TEXT", nullable: false),
                    CzasReakcjiMin = table.Column<int>(type: "INTEGER", nullable: false),
                    CzasRozwiazaniaMin = table.Column<int>(type: "INTEGER", nullable: false),
                    DataRozpoczecia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UmowySla", x => x.umowa_id);
                    table.ForeignKey(
                        name: "FK_UmowySla_Konta_kontoId",
                        column: x => x.kontoId,
                        principalTable: "Konta",
                        principalColumn: "kontoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UmowySla_kontoId",
                table: "UmowySla",
                column: "kontoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UmowySla");
        }
    }
}
