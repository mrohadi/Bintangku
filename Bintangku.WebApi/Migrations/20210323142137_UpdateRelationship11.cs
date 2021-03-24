using Microsoft.EntityFrameworkCore.Migrations;

namespace Bintangku.WebApi.Migrations
{
    public partial class UpdateRelationship11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataAnaks_AspNetUsers_NakesUserId",
                table: "DataAnaks");

            migrationBuilder.AlterColumn<int>(
                name: "NakesUserId",
                table: "DataAnaks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DataAnaks_AspNetUsers_NakesUserId",
                table: "DataAnaks",
                column: "NakesUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataAnaks_AspNetUsers_NakesUserId",
                table: "DataAnaks");

            migrationBuilder.AlterColumn<int>(
                name: "NakesUserId",
                table: "DataAnaks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_DataAnaks_AspNetUsers_NakesUserId",
                table: "DataAnaks",
                column: "NakesUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
