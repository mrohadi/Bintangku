using Microsoft.EntityFrameworkCore.Migrations;

namespace Bintangku.Data.Migrations
{
    public partial class RefactorDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KesehatanAnaks_DataAnaks_Id",
                table: "KesehatanAnaks");

            migrationBuilder.DropForeignKey(
                name: "FK_RiwayatKelahirans_DataAnaks_Id",
                table: "RiwayatKelahirans");

            migrationBuilder.DropForeignKey(
                name: "FK_RiwayatOrangTuas_DataAnaks_Id",
                table: "RiwayatOrangTuas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RiwayatOrangTuas",
                table: "RiwayatOrangTuas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RiwayatKelahirans",
                table: "RiwayatKelahirans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KesehatanAnaks",
                table: "KesehatanAnaks");

            migrationBuilder.RenameTable(
                name: "RiwayatOrangTuas",
                newName: "RiwayatOrangTua");

            migrationBuilder.RenameTable(
                name: "RiwayatKelahirans",
                newName: "RiwayatKelahiran");

            migrationBuilder.RenameTable(
                name: "KesehatanAnaks",
                newName: "KesehatanAnak");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RiwayatOrangTua",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RiwayatKelahiran",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "KesehatanAnak",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RiwayatOrangTua",
                table: "RiwayatOrangTua",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RiwayatKelahiran",
                table: "RiwayatKelahiran",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KesehatanAnak",
                table: "KesehatanAnak",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RiwayatOrangTua_DataAnakId",
                table: "RiwayatOrangTua",
                column: "DataAnakId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RiwayatKelahiran_DataAnakId",
                table: "RiwayatKelahiran",
                column: "DataAnakId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KesehatanAnak_DataAnakId",
                table: "KesehatanAnak",
                column: "DataAnakId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KesehatanAnak_DataAnaks_DataAnakId",
                table: "KesehatanAnak",
                column: "DataAnakId",
                principalTable: "DataAnaks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RiwayatKelahiran_DataAnaks_DataAnakId",
                table: "RiwayatKelahiran",
                column: "DataAnakId",
                principalTable: "DataAnaks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RiwayatOrangTua_DataAnaks_DataAnakId",
                table: "RiwayatOrangTua",
                column: "DataAnakId",
                principalTable: "DataAnaks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KesehatanAnak_DataAnaks_DataAnakId",
                table: "KesehatanAnak");

            migrationBuilder.DropForeignKey(
                name: "FK_RiwayatKelahiran_DataAnaks_DataAnakId",
                table: "RiwayatKelahiran");

            migrationBuilder.DropForeignKey(
                name: "FK_RiwayatOrangTua_DataAnaks_DataAnakId",
                table: "RiwayatOrangTua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RiwayatOrangTua",
                table: "RiwayatOrangTua");

            migrationBuilder.DropIndex(
                name: "IX_RiwayatOrangTua_DataAnakId",
                table: "RiwayatOrangTua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RiwayatKelahiran",
                table: "RiwayatKelahiran");

            migrationBuilder.DropIndex(
                name: "IX_RiwayatKelahiran_DataAnakId",
                table: "RiwayatKelahiran");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KesehatanAnak",
                table: "KesehatanAnak");

            migrationBuilder.DropIndex(
                name: "IX_KesehatanAnak_DataAnakId",
                table: "KesehatanAnak");

            migrationBuilder.RenameTable(
                name: "RiwayatOrangTua",
                newName: "RiwayatOrangTuas");

            migrationBuilder.RenameTable(
                name: "RiwayatKelahiran",
                newName: "RiwayatKelahirans");

            migrationBuilder.RenameTable(
                name: "KesehatanAnak",
                newName: "KesehatanAnaks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RiwayatOrangTuas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RiwayatKelahirans",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "KesehatanAnaks",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RiwayatOrangTuas",
                table: "RiwayatOrangTuas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RiwayatKelahirans",
                table: "RiwayatKelahirans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KesehatanAnaks",
                table: "KesehatanAnaks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KesehatanAnaks_DataAnaks_Id",
                table: "KesehatanAnaks",
                column: "Id",
                principalTable: "DataAnaks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RiwayatKelahirans_DataAnaks_Id",
                table: "RiwayatKelahirans",
                column: "Id",
                principalTable: "DataAnaks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RiwayatOrangTuas_DataAnaks_Id",
                table: "RiwayatOrangTuas",
                column: "Id",
                principalTable: "DataAnaks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
