using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketSysteemRandy.Migrations
{
    public partial class ticked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAdres = table.Column<string>(nullable: false),
                    Voornaam = table.Column<string>(nullable: false),
                    Tussenvoegsels = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: false),
                    Telefoonnummer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAdres = table.Column<string>(nullable: false),
                    Voornaam = table.Column<string>(nullable: false),
                    Tussenvoegsels = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: false),
                    Telefoonnummer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statussen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Volgorde = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statussen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applicaties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false),
                    BeheerderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicaties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applicaties_Medewerkers_BeheerderId",
                        column: x => x.BeheerderId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantId = table.Column<int>(nullable: false),
                    ApplicatieId = table.Column<int>(nullable: false),
                    Onderwerp = table.Column<string>(maxLength: 60, nullable: false),
                    Omschrijving = table.Column<string>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Applicaties_ApplicatieId",
                        column: x => x.ApplicatieId,
                        principalTable: "Applicaties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Statussen_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statussen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Statussen",
                columns: new[] { "Id", "Naam", "Volgorde" },
                values: new object[] { -1, "Nieuw", 100 });

            migrationBuilder.InsertData(
                table: "Statussen",
                columns: new[] { "Id", "Naam", "Volgorde" },
                values: new object[] { -2, "In behandeling", 200 });

            migrationBuilder.InsertData(
                table: "Statussen",
                columns: new[] { "Id", "Naam", "Volgorde" },
                values: new object[] { -3, "Afgehandeld", 300 });

            migrationBuilder.CreateIndex(
                name: "IX_Applicaties_BeheerderId",
                table: "Applicaties",
                column: "BeheerderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ApplicatieId",
                table: "Tickets",
                column: "ApplicatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_KlantId",
                table: "Tickets",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Applicaties");

            migrationBuilder.DropTable(
                name: "Klanten");

            migrationBuilder.DropTable(
                name: "Statussen");

            migrationBuilder.DropTable(
                name: "Medewerkers");
        }
    }
}
