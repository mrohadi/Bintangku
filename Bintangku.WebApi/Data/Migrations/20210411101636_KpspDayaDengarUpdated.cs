using Microsoft.EntityFrameworkCore.Migrations;

namespace Bintangku.WebApi.Data.Migrations
{
    public partial class KpspDayaDengarUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayaDengarDetail_PemeriksaanDayaDengars_PemeriksaanDayaDeng~",
                table: "DayaDengarDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_KpspDetail_PemeriksaanKpsps_PemeriksaanKpspId",
                table: "KpspDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KpspDetail",
                table: "KpspDetail");

            migrationBuilder.DropIndex(
                name: "IX_KpspDetail_PemeriksaanKpspId",
                table: "KpspDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayaDengarDetail",
                table: "DayaDengarDetail");

            migrationBuilder.DropColumn(
                name: "PemeriksaanKpspId",
                table: "KpspDetail");

            migrationBuilder.RenameTable(
                name: "KpspDetail",
                newName: "KpspDetails");

            migrationBuilder.RenameTable(
                name: "DayaDengarDetail",
                newName: "DayaDengarDetails");

            migrationBuilder.RenameIndex(
                name: "IX_DayaDengarDetail_PemeriksaanDayaDengarId",
                table: "DayaDengarDetails",
                newName: "IX_DayaDengarDetails_PemeriksaanDayaDengarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KpspDetails",
                table: "KpspDetails",
                column: "KpspDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayaDengarDetails",
                table: "DayaDengarDetails",
                column: "DayaDengarDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_KpspDetails_PemeriksaasnKpspId",
                table: "KpspDetails",
                column: "PemeriksaasnKpspId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayaDengarDetails_PemeriksaanDayaDengars_PemeriksaanDayaDen~",
                table: "DayaDengarDetails",
                column: "PemeriksaanDayaDengarId",
                principalTable: "PemeriksaanDayaDengars",
                principalColumn: "PemeriksaanDayaDengarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KpspDetails_PemeriksaanKpsps_PemeriksaasnKpspId",
                table: "KpspDetails",
                column: "PemeriksaasnKpspId",
                principalTable: "PemeriksaanKpsps",
                principalColumn: "PemeriksaanKpspId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayaDengarDetails_PemeriksaanDayaDengars_PemeriksaanDayaDen~",
                table: "DayaDengarDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_KpspDetails_PemeriksaanKpsps_PemeriksaasnKpspId",
                table: "KpspDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KpspDetails",
                table: "KpspDetails");

            migrationBuilder.DropIndex(
                name: "IX_KpspDetails_PemeriksaasnKpspId",
                table: "KpspDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayaDengarDetails",
                table: "DayaDengarDetails");

            migrationBuilder.RenameTable(
                name: "KpspDetails",
                newName: "KpspDetail");

            migrationBuilder.RenameTable(
                name: "DayaDengarDetails",
                newName: "DayaDengarDetail");

            migrationBuilder.RenameIndex(
                name: "IX_DayaDengarDetails_PemeriksaanDayaDengarId",
                table: "DayaDengarDetail",
                newName: "IX_DayaDengarDetail_PemeriksaanDayaDengarId");

            migrationBuilder.AddColumn<int>(
                name: "PemeriksaanKpspId",
                table: "KpspDetail",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KpspDetail",
                table: "KpspDetail",
                column: "KpspDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayaDengarDetail",
                table: "DayaDengarDetail",
                column: "DayaDengarDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_KpspDetail_PemeriksaanKpspId",
                table: "KpspDetail",
                column: "PemeriksaanKpspId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayaDengarDetail_PemeriksaanDayaDengars_PemeriksaanDayaDeng~",
                table: "DayaDengarDetail",
                column: "PemeriksaanDayaDengarId",
                principalTable: "PemeriksaanDayaDengars",
                principalColumn: "PemeriksaanDayaDengarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KpspDetail_PemeriksaanKpsps_PemeriksaanKpspId",
                table: "KpspDetail",
                column: "PemeriksaanKpspId",
                principalTable: "PemeriksaanKpsps",
                principalColumn: "PemeriksaanKpspId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
