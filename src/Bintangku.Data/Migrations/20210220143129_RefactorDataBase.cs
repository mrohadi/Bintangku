using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bintangku.Data.Migrations
{
    public partial class RefactorDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NakesUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NoStrTenagaKesehatan = table.Column<long>(type: "INTEGER", nullable: false),
                    TempatPelayanan = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastActive = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NakesUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataAnaks",
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
                    JumlahSaudara = table.Column<byte>(type: "INTEGER", nullable: false),
                    BeratBadan = table.Column<byte>(type: "INTEGER", nullable: false),
                    PanjangLahir = table.Column<int>(type: "INTEGER", nullable: false),
                    ApgarScore = table.Column<int>(type: "INTEGER", nullable: false),
                    KelahiranDibantuOleh = table.Column<string>(type: "TEXT", nullable: true),
                    LainLain = table.Column<string>(type: "TEXT", nullable: true),
                    PekerjaanOrangTua = table.Column<string>(type: "TEXT", nullable: true),
                    PenghasilanOranTua = table.Column<float>(type: "REAL", nullable: false),
                    AnggotaRumahTangga = table.Column<byte>(type: "INTEGER", nullable: false),
                    TandaTanganOrangTua = table.Column<string>(type: "TEXT", nullable: true),
                    NakesUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataAnaks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataAnaks_NakesUsers_NakesUserId",
                        column: x => x.NakesUserId,
                        principalTable: "NakesUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true),
                    NakesUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_NakesUsers_NakesUserId",
                        column: x => x.NakesUserId,
                        principalTable: "NakesUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhotoAnak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true),
                    DataAnakId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoAnak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoAnak_DataAnaks_DataAnakId",
                        column: x => x.DataAnakId,
                        principalTable: "DataAnaks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataAnaks_NakesUserId",
                table: "DataAnaks",
                column: "NakesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoAnak_DataAnakId",
                table: "PhotoAnak",
                column: "DataAnakId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_NakesUserId",
                table: "Photos",
                column: "NakesUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoAnak");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "DataAnaks");

            migrationBuilder.DropTable(
                name: "NakesUsers");
        }
    }
}
