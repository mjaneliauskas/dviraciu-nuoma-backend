using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dviraciu_nuoma_backend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dviratis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    dviracioPavadinimas = table.Column<string>(type: "text", nullable: false),
                    DviracioTipas = table.Column<int>(type: "integer", nullable: false),
                    DviracioKaina = table.Column<double>(type: "double precision", nullable: false),
                    DviracioSpecifikacija = table.Column<string>(type: "text", nullable: false),
                    DviracioStatusas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dviratis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PrisijungimoVardas = table.Column<string>(type: "text", nullable: false),
                    ElPastas = table.Column<string>(type: "text", nullable: false),
                    Slaptazodis = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kelione",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KelionesPradzia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    KelionesPabaiga = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VartotojasId = table.Column<Guid>(type: "uuid", nullable: false),
                    DviratisId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kelione", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kelione_Dviratis_DviratisId",
                        column: x => x.DviratisId,
                        principalTable: "Dviratis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kelione_User_VartotojasId",
                        column: x => x.VartotojasId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kelione_DviratisId",
                table: "Kelione",
                column: "DviratisId");

            migrationBuilder.CreateIndex(
                name: "IX_Kelione_VartotojasId",
                table: "Kelione",
                column: "VartotojasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kelione");

            migrationBuilder.DropTable(
                name: "Dviratis");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
