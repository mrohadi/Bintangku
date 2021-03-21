using Microsoft.EntityFrameworkCore.Migrations;

namespace Bintangku.WebApi.Data.Migrations
{
    public partial class UpdateTtd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TandaTanganOrangTua",
                table: "RiwayatOrangTua",
                newName: "TandaTanganPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TandaTanganPath",
                table: "RiwayatOrangTua",
                newName: "TandaTanganOrangTua");
        }
    }
}
