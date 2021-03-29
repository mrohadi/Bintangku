using Microsoft.EntityFrameworkCore.Migrations;

namespace Bintangku.WebApi.Data.Migrations
{
    public partial class UpdateKesehatanAnak3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JumlahYa",
                table: "PemeriksaanKesehatanM-CHAT",
                newName: "TotalQuestionYes");

            migrationBuilder.RenameColumn(
                name: "JumlahTidak",
                table: "PemeriksaanKesehatanM-CHAT",
                newName: "TotalQuestionNo");

            migrationBuilder.AddColumn<int>(
                name: "TotalCriticalQuestionNo",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCriticalQuestionYes",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCriticalQuestionNo",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "TotalCriticalQuestionYes",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.RenameColumn(
                name: "TotalQuestionYes",
                table: "PemeriksaanKesehatanM-CHAT",
                newName: "JumlahYa");

            migrationBuilder.RenameColumn(
                name: "TotalQuestionNo",
                table: "PemeriksaanKesehatanM-CHAT",
                newName: "JumlahTidak");
        }
    }
}
