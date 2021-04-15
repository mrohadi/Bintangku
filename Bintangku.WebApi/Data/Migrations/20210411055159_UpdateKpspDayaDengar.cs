using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bintangku.WebApi.Data.Migrations
{
    public partial class UpdateKpspDayaDengar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interpretasi",
                table: "PemeriksaanKpsps");

            migrationBuilder.DropColumn(
                name: "JumlahYa",
                table: "PemeriksaanKpsps");

            migrationBuilder.DropColumn(
                name: "Tindakan",
                table: "PemeriksaanKpsps");

            migrationBuilder.DropColumn(
                name: "Interpretasi",
                table: "PemeriksaanDayaDengars");

            migrationBuilder.DropColumn(
                name: "Intervensi",
                table: "PemeriksaanDayaDengars");

            migrationBuilder.CreateTable(
                name: "DayaDengarDetail",
                columns: table => new
                {
                    DayaDengarDetailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    JumlahYa = table.Column<int>(type: "integer", nullable: false),
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    PemeriksaanDayaDengarId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayaDengarDetail", x => x.DayaDengarDetailId);
                    table.ForeignKey(
                        name: "FK_DayaDengarDetail_PemeriksaanDayaDengars_PemeriksaanDayaDeng~",
                        column: x => x.PemeriksaanDayaDengarId,
                        principalTable: "PemeriksaanDayaDengars",
                        principalColumn: "PemeriksaanDayaDengarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KpspDetail",
                columns: table => new
                {
                    KpspDetailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: true),
                    JumlahYa = table.Column<int>(type: "integer", nullable: false),
                    GerakKasar = table.Column<int>(type: "integer", nullable: false),
                    GerakHalus = table.Column<int>(type: "integer", nullable: false),
                    BicaraDanBahasa = table.Column<int>(type: "integer", nullable: false),
                    SosialisasiDanKemandirian = table.Column<int>(type: "integer", nullable: false),
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Tindakan = table.Column<string>(type: "text", nullable: true),
                    PemeriksaasnKpspId = table.Column<int>(type: "integer", nullable: false),
                    PemeriksaanKpspId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KpspDetail", x => x.KpspDetailId);
                    table.ForeignKey(
                        name: "FK_KpspDetail_PemeriksaanKpsps_PemeriksaanKpspId",
                        column: x => x.PemeriksaanKpspId,
                        principalTable: "PemeriksaanKpsps",
                        principalColumn: "PemeriksaanKpspId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayaDengarDetail_PemeriksaanDayaDengarId",
                table: "DayaDengarDetail",
                column: "PemeriksaanDayaDengarId");

            migrationBuilder.CreateIndex(
                name: "IX_KpspDetail_PemeriksaanKpspId",
                table: "KpspDetail",
                column: "PemeriksaanKpspId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayaDengarDetail");

            migrationBuilder.DropTable(
                name: "KpspDetail");

            migrationBuilder.AddColumn<string>(
                name: "Interpretasi",
                table: "PemeriksaanKpsps",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JumlahYa",
                table: "PemeriksaanKpsps",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tindakan",
                table: "PemeriksaanKpsps",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interpretasi",
                table: "PemeriksaanDayaDengars",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Intervensi",
                table: "PemeriksaanDayaDengars",
                type: "text",
                nullable: true);
        }
    }
}
