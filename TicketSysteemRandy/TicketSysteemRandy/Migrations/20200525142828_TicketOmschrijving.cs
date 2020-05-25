using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketSysteemRandy.Migrations
{
    public partial class TicketOmschrijving : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Omschrijvingen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(nullable: false),
                    DatumTijd = table.Column<DateTime>(nullable: false),
                    Tekst = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Omschrijvingen", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Omschrijvingen");
        }
    }
}
