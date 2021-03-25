using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bintangku.WebApi.Migrations
{
    public partial class AddPemeriksaan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PemeriksaanKesehatanGPPH",
                columns: table => new
                {
                    PemeriksaanGpphId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Point = table.Column<byte>(type: "smallint", nullable: false),
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PemeriksaanKesehatanGPPH", x => x.PemeriksaanGpphId);
                    table.ForeignKey(
                        name: "FK_PemeriksaanKesehatanGPPH_KesehatanAnak_KesehatanAnakId",
                        column: x => x.KesehatanAnakId,
                        principalTable: "KesehatanAnak",
                        principalColumn: "KesehatanAnakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PemeriksaanKesehatanKMPE",
                columns: table => new
                {
                    PemeriksaanKmpeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JumlahYa = table.Column<byte>(type: "smallint", nullable: false),
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PemeriksaanKesehatanKMPE", x => x.PemeriksaanKmpeId);
                    table.ForeignKey(
                        name: "FK_PemeriksaanKesehatanKMPE_KesehatanAnak_KesehatanAnakId",
                        column: x => x.KesehatanAnakId,
                        principalTable: "KesehatanAnak",
                        principalColumn: "KesehatanAnakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PemeriksaanKesehatanM-CHAT",
                columns: table => new
                {
                    PemeriksaanMchatId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JumlahYa = table.Column<int>(type: "integer", nullable: false),
                    JumlahTidak = table.Column<int>(type: "integer", nullable: false),
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PemeriksaanKesehatanM-CHAT", x => x.PemeriksaanMchatId);
                    table.ForeignKey(
                        name: "FK_PemeriksaanKesehatanM-CHAT_KesehatanAnak_KesehatanAnakId",
                        column: x => x.KesehatanAnakId,
                        principalTable: "KesehatanAnak",
                        principalColumn: "KesehatanAnakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PemeriksaanKesehatanGPPH_KesehatanAnakId",
                table: "PemeriksaanKesehatanGPPH",
                column: "KesehatanAnakId");

            migrationBuilder.CreateIndex(
                name: "IX_PemeriksaanKesehatanKMPE_KesehatanAnakId",
                table: "PemeriksaanKesehatanKMPE",
                column: "KesehatanAnakId");

            migrationBuilder.CreateIndex(
                name: "IX_PemeriksaanKesehatanM-CHAT_KesehatanAnakId",
                table: "PemeriksaanKesehatanM-CHAT",
                column: "KesehatanAnakId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PemeriksaanKesehatanGPPH");

            migrationBuilder.DropTable(
                name: "PemeriksaanKesehatanKMPE");

            migrationBuilder.DropTable(
                name: "PemeriksaanKesehatanM-CHAT");
        }
    }
}
