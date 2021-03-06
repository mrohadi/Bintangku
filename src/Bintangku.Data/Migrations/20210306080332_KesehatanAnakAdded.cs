using Microsoft.EntityFrameworkCore.Migrations;

namespace Bintangku.Data.Migrations
{
    public partial class KesehatanAnakAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KesehatanAnak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusGiziBbTb = table.Column<string>(type: "TEXT", nullable: true),
                    StatusGiziImtU = table.Column<string>(type: "TEXT", nullable: true),
                    StatusGiziIpTb = table.Column<string>(type: "TEXT", nullable: true),
                    LingkarKepala = table.Column<string>(type: "TEXT", nullable: true),
                    Kpsp = table.Column<string>(type: "TEXT", nullable: true),
                    DayaDengar = table.Column<string>(type: "TEXT", nullable: true),
                    DayaLihat = table.Column<string>(type: "TEXT", nullable: true),
                    Kmpe = table.Column<string>(type: "TEXT", nullable: true),
                    Mchat = table.Column<string>(type: "TEXT", nullable: true),
                    Gpph = table.Column<string>(type: "TEXT", nullable: true),
                    DataAnakId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KesehatanAnak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KesehatanAnak_DataAnaks_Id",
                        column: x => x.Id,
                        principalTable: "DataAnaks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KesehatanAnak");
        }
    }
}
