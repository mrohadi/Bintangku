using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bintangku.Data.Migrations
{
    public partial class DataUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoAnak");

            migrationBuilder.DropColumn(
                name: "AnggotaRumahTangga",
                table: "DataAnaks");

            migrationBuilder.DropColumn(
                name: "ApgarScore",
                table: "DataAnaks");

            migrationBuilder.DropColumn(
                name: "BeratBadan",
                table: "DataAnaks");

            migrationBuilder.DropColumn(
                name: "KelahiranDibantuOleh",
                table: "DataAnaks");

            migrationBuilder.DropColumn(
                name: "LainLain",
                table: "DataAnaks");

            migrationBuilder.DropColumn(
                name: "NamaAyah",
                table: "DataAnaks");

            migrationBuilder.DropColumn(
                name: "NamaIbu",
                table: "DataAnaks");

            migrationBuilder.DropColumn(
                name: "PanjangLahir",
                table: "DataAnaks");

            migrationBuilder.DropColumn(
                name: "PekerjaanOrangTua",
                table: "DataAnaks");

            migrationBuilder.DropColumn(
                name: "PenghasilanOranTua",
                table: "DataAnaks");

            migrationBuilder.RenameColumn(
                name: "TandaTanganOrangTua",
                table: "DataAnaks",
                newName: "PhotoAnakUrl");

            migrationBuilder.CreateTable(
                name: "RiwayatKelahirans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    BearatBadan = table.Column<byte>(type: "INTEGER", nullable: false),
                    PanjangLaahir = table.Column<int>(type: "INTEGER", nullable: false),
                    ApgarScore = table.Column<int>(type: "INTEGER", nullable: false),
                    KelahiranDibantuOleh = table.Column<string>(type: "TEXT", nullable: true),
                    LainLain = table.Column<string>(type: "TEXT", nullable: true),
                    DataAnakId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiwayatKelahirans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiwayatKelahirans_DataAnaks_Id",
                        column: x => x.Id,
                        principalTable: "DataAnaks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiwayatOrangTuas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    NamaAyah = table.Column<string>(type: "TEXT", nullable: true),
                    TanggalLahirAyah = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PekerjaanAyah = table.Column<string>(type: "TEXT", nullable: true),
                    NamaIbu = table.Column<string>(type: "TEXT", nullable: true),
                    TanggalLahirIbu = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PekerjaanIbu = table.Column<string>(type: "TEXT", nullable: true),
                    PenghasilanOrangTua = table.Column<float>(type: "REAL", nullable: false),
                    AnggotaRumahTangga = table.Column<byte>(type: "INTEGER", nullable: false),
                    TandaTanganOrangTua = table.Column<string>(type: "TEXT", nullable: true),
                    DataAnakId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiwayatOrangTuas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiwayatOrangTuas_DataAnaks_Id",
                        column: x => x.Id,
                        principalTable: "DataAnaks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiwayatKelahirans");

            migrationBuilder.DropTable(
                name: "RiwayatOrangTuas");

            migrationBuilder.RenameColumn(
                name: "PhotoAnakUrl",
                table: "DataAnaks",
                newName: "TandaTanganOrangTua");

            migrationBuilder.AddColumn<byte>(
                name: "AnggotaRumahTangga",
                table: "DataAnaks",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "ApgarScore",
                table: "DataAnaks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "BeratBadan",
                table: "DataAnaks",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "KelahiranDibantuOleh",
                table: "DataAnaks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LainLain",
                table: "DataAnaks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaAyah",
                table: "DataAnaks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaIbu",
                table: "DataAnaks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PanjangLahir",
                table: "DataAnaks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PekerjaanOrangTua",
                table: "DataAnaks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PenghasilanOranTua",
                table: "DataAnaks",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "PhotoAnak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataAnakId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "IX_PhotoAnak_DataAnakId",
                table: "PhotoAnak",
                column: "DataAnakId");
        }
    }
}
