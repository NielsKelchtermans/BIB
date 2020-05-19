using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BIBData.Migrations
{
    public partial class opnieuw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operatingsystemen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operatingsystemen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uitleenobjecten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Jaar = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Kostprijs = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(nullable: true),
                    Auteur = table.Column<string>(nullable: true),
                    Aantalpaginas = table.Column<int>(nullable: true),
                    OperatingsysteemId = table.Column<int>(nullable: true),
                    Schermgrootte = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uitleenobjecten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uitleenobjecten_Operatingsystemen_OperatingsysteemId",
                        column: x => x.OperatingsysteemId,
                        principalTable: "Operatingsystemen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserveringen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UitleenobjectId = table.Column<int>(nullable: true),
                    LenerId = table.Column<int>(nullable: true),
                    GereserveerdOp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Leners_LenerId",
                        column: x => x.LenerId,
                        principalTable: "Leners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Uitleenobjecten_UitleenobjectId",
                        column: x => x.UitleenobjectId,
                        principalTable: "Uitleenobjecten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uitleningen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UitleenobjectId = table.Column<int>(nullable: true),
                    LenerId = table.Column<int>(nullable: true),
                    Van = table.Column<DateTime>(nullable: false),
                    Tot = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uitleningen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uitleningen_Leners_LenerId",
                        column: x => x.LenerId,
                        principalTable: "Leners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uitleningen_Uitleenobjecten_UitleenobjectId",
                        column: x => x.UitleenobjectId,
                        principalTable: "Uitleenobjecten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_LenerId",
                table: "Reserveringen",
                column: "LenerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_UitleenobjectId",
                table: "Reserveringen",
                column: "UitleenobjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Uitleenobjecten_OperatingsysteemId",
                table: "Uitleenobjecten",
                column: "OperatingsysteemId");

            migrationBuilder.CreateIndex(
                name: "IX_Uitleningen_LenerId",
                table: "Uitleningen",
                column: "LenerId");

            migrationBuilder.CreateIndex(
                name: "IX_Uitleningen_UitleenobjectId",
                table: "Uitleningen",
                column: "UitleenobjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserveringen");

            migrationBuilder.DropTable(
                name: "Uitleningen");

            migrationBuilder.DropTable(
                name: "Uitleenobjecten");

            migrationBuilder.DropTable(
                name: "Operatingsystemen");
        }
    }
}
