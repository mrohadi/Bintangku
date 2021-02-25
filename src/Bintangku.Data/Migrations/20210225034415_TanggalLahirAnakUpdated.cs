using Microsoft.EntityFrameworkCore.Migrations;

namespace Bintangku.Data.Migrations
{
    public partial class TanggalLahirAnakUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TanggalLahir",
                table: "DataAnaks",
                newName: "TanggalLahirAnak");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TanggalLahirAnak",
                table: "DataAnaks",
                newName: "TanggalLahir");
        }
    }
}
