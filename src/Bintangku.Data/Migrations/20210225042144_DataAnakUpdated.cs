using Microsoft.EntityFrameworkCore.Migrations;

namespace Bintangku.Data.Migrations
{
    public partial class DataAnakUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PanjangLaahir",
                table: "RiwayatKelahirans",
                newName: "PanjangLahir");

            migrationBuilder.RenameColumn(
                name: "BearatBadan",
                table: "RiwayatKelahirans",
                newName: "BeratBadan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PanjangLahir",
                table: "RiwayatKelahirans",
                newName: "PanjangLaahir");

            migrationBuilder.RenameColumn(
                name: "BeratBadan",
                table: "RiwayatKelahirans",
                newName: "BearatBadan");
        }
    }
}
