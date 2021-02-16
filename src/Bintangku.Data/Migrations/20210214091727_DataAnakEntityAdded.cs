using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bintangku.Data.Migrations
{
    public partial class DataAnakEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataAnak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NamaLengkap = table.Column<string>(type: "TEXT", nullable: true),
                    NIK = table.Column<int>(type: "INTEGER", nullable: false),
                    JenisKelamin = table.Column<string>(type: "TEXT", nullable: true),
                    TanggalLahir = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NamaAyah = table.Column<string>(type: "TEXT", nullable: true),
                    NamaIbu = table.Column<string>(type: "TEXT", nullable: true),
                    Alamat = table.Column<string>(type: "TEXT", nullable: true),
                    Kontak = table.Column<string>(type: "TEXT", nullable: true),
                    NakesUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataAnak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataAnak_NakesUsers_NakesUserId",
                        column: x => x.NakesUserId,
                        principalTable: "NakesUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataAnak_NakesUserId",
                table: "DataAnak",
                column: "NakesUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataAnak");
        }
    }
}
