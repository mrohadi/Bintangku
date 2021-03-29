using Microsoft.EntityFrameworkCore.Migrations;

namespace Bintangku.WebApi.Data.Migrations
{
    public partial class UpdateKesehatanAnak1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gpph",
                table: "KesehatanAnak");

            migrationBuilder.DropColumn(
                name: "Kmpe",
                table: "KesehatanAnak");

            migrationBuilder.DropColumn(
                name: "Mchat",
                table: "KesehatanAnak");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gpph",
                table: "KesehatanAnak",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kmpe",
                table: "KesehatanAnak",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mchat",
                table: "KesehatanAnak",
                type: "text",
                nullable: true);
        }
    }
}
