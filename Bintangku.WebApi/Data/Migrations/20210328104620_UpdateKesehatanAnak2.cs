using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bintangku.WebApi.Data.Migrations
{
    public partial class UpdateKesehatanAnak2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MChat");

            migrationBuilder.AddColumn<bool>(
                name: "Question1",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question10",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question11",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question12",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question13",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question14",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question15",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question16",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question17",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question18",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question19",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question2",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question20",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question21",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question22",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question23",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question3",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question4",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question5",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question6",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question7",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question8",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Question9",
                table: "PemeriksaanKesehatanM-CHAT",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question1",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question10",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question11",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question12",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question13",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question14",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question15",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question16",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question17",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question18",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question19",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question2",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question20",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question21",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question22",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question23",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question3",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question4",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question5",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question6",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question7",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question8",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropColumn(
                name: "Question9",
                table: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.CreateTable(
                name: "MChat",
                columns: table => new
                {
                    MChatId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    A = table.Column<bool>(type: "boolean", nullable: false),
                    B = table.Column<bool>(type: "boolean", nullable: false),
                    C = table.Column<bool>(type: "boolean", nullable: false),
                    D = table.Column<bool>(type: "boolean", nullable: false),
                    E = table.Column<bool>(type: "boolean", nullable: false),
                    F = table.Column<bool>(type: "boolean", nullable: false),
                    G = table.Column<bool>(type: "boolean", nullable: false),
                    H = table.Column<bool>(type: "boolean", nullable: false),
                    I = table.Column<bool>(type: "boolean", nullable: false),
                    J = table.Column<bool>(type: "boolean", nullable: false),
                    K = table.Column<bool>(type: "boolean", nullable: false),
                    L = table.Column<bool>(type: "boolean", nullable: false),
                    M = table.Column<bool>(type: "boolean", nullable: false),
                    N = table.Column<bool>(type: "boolean", nullable: false),
                    O = table.Column<bool>(type: "boolean", nullable: false),
                    P = table.Column<bool>(type: "boolean", nullable: false),
                    PemeriksaanMchatId = table.Column<int>(type: "integer", nullable: false),
                    Q = table.Column<bool>(type: "boolean", nullable: false),
                    R = table.Column<bool>(type: "boolean", nullable: false),
                    S = table.Column<bool>(type: "boolean", nullable: false),
                    T = table.Column<bool>(type: "boolean", nullable: false),
                    U = table.Column<bool>(type: "boolean", nullable: false),
                    V = table.Column<bool>(type: "boolean", nullable: false),
                    W = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MChat", x => x.MChatId);
                    table.ForeignKey(
                        name: "FK_MChat_PemeriksaanKesehatanM-CHAT_PemeriksaanMchatId",
                        column: x => x.PemeriksaanMchatId,
                        principalTable: "PemeriksaanKesehatanM-CHAT",
                        principalColumn: "PemeriksaanMchatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MChat_PemeriksaanMchatId",
                table: "MChat",
                column: "PemeriksaanMchatId");
        }
    }
}
