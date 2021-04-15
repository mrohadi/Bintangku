using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bintangku.WebApi.Data.Migrations
{
    public partial class RefactorDataBase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KpspDetails_PemeriksaanKpsps_PemeriksaasnKpspId",
                table: "KpspDetails");

            migrationBuilder.DropTable(
                name: "DayaDengarDetails");

            migrationBuilder.DropTable(
                name: "PemeriksaanDayaLihats");

            migrationBuilder.DropTable(
                name: "PemeriksaanKesehatanGPPH");

            migrationBuilder.DropTable(
                name: "PemeriksaanKesehatanKMPE");

            migrationBuilder.DropTable(
                name: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropTable(
                name: "PemeriksaanKpsps");

            migrationBuilder.DropTable(
                name: "PemeriksaanLingkarKepalas");

            migrationBuilder.DropTable(
                name: "PemeriksaanStatusGiziBbTbs");

            migrationBuilder.DropTable(
                name: "PemeriksaanStatusGiziImtUs");

            migrationBuilder.DropTable(
                name: "PemeriksaanStatusGiziIpTbs");

            migrationBuilder.DropTable(
                name: "RiwayatKelahiran");

            migrationBuilder.DropTable(
                name: "RiwayatOrangTua");

            migrationBuilder.DropTable(
                name: "PemeriksaanDayaDengars");

            migrationBuilder.DropTable(
                name: "KesehatanAnak");

            migrationBuilder.DropTable(
                name: "DataAnaks");

            migrationBuilder.RenameColumn(
                name: "PemeriksaasnKpspId",
                table: "KpspDetails",
                newName: "KpspCheckupId");

            migrationBuilder.RenameIndex(
                name: "IX_KpspDetails_PemeriksaasnKpspId",
                table: "KpspDetails",
                newName: "IX_KpspDetails_KpspCheckupId");

            migrationBuilder.CreateTable(
                name: "ChildDatas",
                columns: table => new
                {
                    ChildDataId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    NIK = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Kontak = table.Column<string>(type: "text", nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    NumberOfSiblings = table.Column<byte>(type: "smallint", nullable: false),
                    NakesUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildDatas", x => x.ChildDataId);
                    table.ForeignKey(
                        name: "FK_ChildDatas_AspNetUsers_NakesUserId",
                        column: x => x.NakesUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BirthHistory",
                columns: table => new
                {
                    BirthHistoryId = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<byte>(type: "smallint", nullable: false),
                    Length = table.Column<int>(type: "integer", nullable: false),
                    ApgarScore = table.Column<int>(type: "integer", nullable: false),
                    BirthAssistedBy = table.Column<string>(type: "text", nullable: true),
                    Etc = table.Column<string>(type: "text", nullable: true),
                    ChildDataId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthHistory", x => x.BirthHistoryId);
                    table.ForeignKey(
                        name: "FK_BirthHistory_ChildDatas_BirthHistoryId",
                        column: x => x.BirthHistoryId,
                        principalTable: "ChildDatas",
                        principalColumn: "ChildDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildHealth",
                columns: table => new
                {
                    ChildHealthId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PemeriksaanBeratBadan = table.Column<int>(type: "integer", nullable: false),
                    PemeriksaanTinggiBadan = table.Column<int>(type: "integer", nullable: false),
                    ChildDataId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildHealth", x => x.ChildHealthId);
                    table.ForeignKey(
                        name: "FK_ChildHealth_ChildDatas_ChildDataId",
                        column: x => x.ChildDataId,
                        principalTable: "ChildDatas",
                        principalColumn: "ChildDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentHistory",
                columns: table => new
                {
                    ParentHistoryId = table.Column<int>(type: "integer", nullable: false),
                    FatherName = table.Column<string>(type: "text", nullable: true),
                    FatherDateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FatherJob = table.Column<string>(type: "text", nullable: true),
                    MotherName = table.Column<string>(type: "text", nullable: true),
                    MotherDateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MotherJob = table.Column<string>(type: "text", nullable: true),
                    ParentIncome = table.Column<float>(type: "real", nullable: false),
                    HouseholdMember = table.Column<byte>(type: "smallint", nullable: false),
                    SignaturePath = table.Column<string>(type: "text", nullable: true),
                    ChildDataId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentHistory", x => x.ParentHistoryId);
                    table.ForeignKey(
                        name: "FK_ParentHistory_ChildDatas_ParentHistoryId",
                        column: x => x.ParentHistoryId,
                        principalTable: "ChildDatas",
                        principalColumn: "ChildDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GpphCheckup",
                columns: table => new
                {
                    GpphCheckupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Point = table.Column<byte>(type: "smallint", nullable: false),
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    Question1 = table.Column<byte>(type: "smallint", nullable: false),
                    Question2 = table.Column<byte>(type: "smallint", nullable: false),
                    Question3 = table.Column<byte>(type: "smallint", nullable: false),
                    Question4 = table.Column<byte>(type: "smallint", nullable: false),
                    Question5 = table.Column<byte>(type: "smallint", nullable: false),
                    Question6 = table.Column<byte>(type: "smallint", nullable: false),
                    Question7 = table.Column<byte>(type: "smallint", nullable: false),
                    Question8 = table.Column<byte>(type: "smallint", nullable: false),
                    Question9 = table.Column<byte>(type: "smallint", nullable: false),
                    Question10 = table.Column<byte>(type: "smallint", nullable: false),
                    ChildHealthId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpphCheckup", x => x.GpphCheckupId);
                    table.ForeignKey(
                        name: "FK_GpphCheckup_ChildHealth_ChildHealthId",
                        column: x => x.ChildHealthId,
                        principalTable: "ChildHealth",
                        principalColumn: "ChildHealthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeadCircumferenceCheckups",
                columns: table => new
                {
                    HeadCircumferenceCheckupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeadCircumference = table.Column<int>(type: "integer", nullable: false),
                    Curve = table.Column<int>(type: "integer", nullable: false),
                    Classification = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    ChildHealthId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadCircumferenceCheckups", x => x.HeadCircumferenceCheckupId);
                    table.ForeignKey(
                        name: "FK_HeadCircumferenceCheckups_ChildHealth_ChildHealthId",
                        column: x => x.ChildHealthId,
                        principalTable: "ChildHealth",
                        principalColumn: "ChildHealthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HearingPowerCheckups",
                columns: table => new
                {
                    HearingPowerCheckupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChildHealthId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HearingPowerCheckups", x => x.HearingPowerCheckupId);
                    table.ForeignKey(
                        name: "FK_HearingPowerCheckups_ChildHealth_ChildHealthId",
                        column: x => x.ChildHealthId,
                        principalTable: "ChildHealth",
                        principalColumn: "ChildHealthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KmpeCheckup",
                columns: table => new
                {
                    KmpeCheckupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalYes = table.Column<byte>(type: "smallint", nullable: false),
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    Question1 = table.Column<bool>(type: "boolean", nullable: false),
                    Question2 = table.Column<bool>(type: "boolean", nullable: false),
                    Question3 = table.Column<bool>(type: "boolean", nullable: false),
                    Question4 = table.Column<bool>(type: "boolean", nullable: false),
                    Question5 = table.Column<bool>(type: "boolean", nullable: false),
                    Question6 = table.Column<bool>(type: "boolean", nullable: false),
                    Question7 = table.Column<bool>(type: "boolean", nullable: false),
                    Question8 = table.Column<bool>(type: "boolean", nullable: false),
                    Question9 = table.Column<bool>(type: "boolean", nullable: false),
                    Question10 = table.Column<bool>(type: "boolean", nullable: false),
                    Question11 = table.Column<bool>(type: "boolean", nullable: false),
                    Question12 = table.Column<bool>(type: "boolean", nullable: false),
                    Question13 = table.Column<bool>(type: "boolean", nullable: false),
                    Question14 = table.Column<bool>(type: "boolean", nullable: false),
                    ChildHealthId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KmpeCheckup", x => x.KmpeCheckupId);
                    table.ForeignKey(
                        name: "FK_KmpeCheckup_ChildHealth_ChildHealthId",
                        column: x => x.ChildHealthId,
                        principalTable: "ChildHealth",
                        principalColumn: "ChildHealthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KpspCheckups",
                columns: table => new
                {
                    KpspCheckupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChildHealthId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KpspCheckups", x => x.KpspCheckupId);
                    table.ForeignKey(
                        name: "FK_KpspCheckups_ChildHealth_ChildHealthId",
                        column: x => x.ChildHealthId,
                        principalTable: "ChildHealth",
                        principalColumn: "ChildHealthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "M-ChatCheckup",
                columns: table => new
                {
                    MchatCheckupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question1 = table.Column<bool>(type: "boolean", nullable: false),
                    Question2 = table.Column<bool>(type: "boolean", nullable: false),
                    Question3 = table.Column<bool>(type: "boolean", nullable: false),
                    Question4 = table.Column<bool>(type: "boolean", nullable: false),
                    Question5 = table.Column<bool>(type: "boolean", nullable: false),
                    Question6 = table.Column<bool>(type: "boolean", nullable: false),
                    Question7 = table.Column<bool>(type: "boolean", nullable: false),
                    Question8 = table.Column<bool>(type: "boolean", nullable: false),
                    Question9 = table.Column<bool>(type: "boolean", nullable: false),
                    Question10 = table.Column<bool>(type: "boolean", nullable: false),
                    Question11 = table.Column<bool>(type: "boolean", nullable: false),
                    Question12 = table.Column<bool>(type: "boolean", nullable: false),
                    Question13 = table.Column<bool>(type: "boolean", nullable: false),
                    Question14 = table.Column<bool>(type: "boolean", nullable: false),
                    Question15 = table.Column<bool>(type: "boolean", nullable: false),
                    Question16 = table.Column<bool>(type: "boolean", nullable: false),
                    Question17 = table.Column<bool>(type: "boolean", nullable: false),
                    Question18 = table.Column<bool>(type: "boolean", nullable: false),
                    Question19 = table.Column<bool>(type: "boolean", nullable: false),
                    Question20 = table.Column<bool>(type: "boolean", nullable: false),
                    Question21 = table.Column<bool>(type: "boolean", nullable: false),
                    Question22 = table.Column<bool>(type: "boolean", nullable: false),
                    Question23 = table.Column<bool>(type: "boolean", nullable: false),
                    TotalCriticalQuestionYes = table.Column<int>(type: "integer", nullable: false),
                    TotalCriticalQuestionNo = table.Column<int>(type: "integer", nullable: false),
                    TotalQuestionYes = table.Column<int>(type: "integer", nullable: false),
                    TotalQuestionNo = table.Column<int>(type: "integer", nullable: false),
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    ChildHealthId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M-ChatCheckup", x => x.MchatCheckupId);
                    table.ForeignKey(
                        name: "FK_M-ChatCheckup_ChildHealth_ChildHealthId",
                        column: x => x.ChildHealthId,
                        principalTable: "ChildHealth",
                        principalColumn: "ChildHealthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalStatusBbTbCheckups",
                columns: table => new
                {
                    NutritionalStatusBbTbCheckupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    ZCode = table.Column<int>(type: "integer", nullable: false),
                    NutritionalStatus = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    ChildHealthId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalStatusBbTbCheckups", x => x.NutritionalStatusBbTbCheckupId);
                    table.ForeignKey(
                        name: "FK_NutritionalStatusBbTbCheckups_ChildHealth_ChildHealthId",
                        column: x => x.ChildHealthId,
                        principalTable: "ChildHealth",
                        principalColumn: "ChildHealthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalStatusImtUCheckups",
                columns: table => new
                {
                    NutritionalStatusImtUCheckupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    IMT = table.Column<int>(type: "integer", nullable: false),
                    ZCode = table.Column<int>(type: "integer", nullable: false),
                    NutritionalStatus = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    ChildHealthId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalStatusImtUCheckups", x => x.NutritionalStatusImtUCheckupId);
                    table.ForeignKey(
                        name: "FK_NutritionalStatusImtUCheckups_ChildHealth_ChildHealthId",
                        column: x => x.ChildHealthId,
                        principalTable: "ChildHealth",
                        principalColumn: "ChildHealthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalStatusIpTbCheckups",
                columns: table => new
                {
                    NutritionalStatusIpTbCheckupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    IndexLength = table.Column<int>(type: "integer", nullable: false),
                    ZCode = table.Column<int>(type: "integer", nullable: false),
                    NutritionalStatus = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    ChildHealthId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalStatusIpTbCheckups", x => x.NutritionalStatusIpTbCheckupId);
                    table.ForeignKey(
                        name: "FK_NutritionalStatusIpTbCheckups_ChildHealth_ChildHealthId",
                        column: x => x.ChildHealthId,
                        principalTable: "ChildHealth",
                        principalColumn: "ChildHealthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisionCheckups",
                columns: table => new
                {
                    VisionCheckupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RightEye = table.Column<int>(type: "integer", nullable: false),
                    LeftEye = table.Column<int>(type: "integer", nullable: false),
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    ChildHealthId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisionCheckups", x => x.VisionCheckupId);
                    table.ForeignKey(
                        name: "FK_VisionCheckups_ChildHealth_ChildHealthId",
                        column: x => x.ChildHealthId,
                        principalTable: "ChildHealth",
                        principalColumn: "ChildHealthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HearingPowerDetails",
                columns: table => new
                {
                    HearingPowerDetailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    TotalYes = table.Column<int>(type: "integer", nullable: false),
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    HearingPowerCheckupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HearingPowerDetails", x => x.HearingPowerDetailId);
                    table.ForeignKey(
                        name: "FK_HearingPowerDetails_HearingPowerCheckups_HearingPowerChecku~",
                        column: x => x.HearingPowerCheckupId,
                        principalTable: "HearingPowerCheckups",
                        principalColumn: "HearingPowerCheckupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildDatas_NakesUserId",
                table: "ChildDatas",
                column: "NakesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildHealth_ChildDataId",
                table: "ChildHealth",
                column: "ChildDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GpphCheckup_ChildHealthId",
                table: "GpphCheckup",
                column: "ChildHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadCircumferenceCheckups_ChildHealthId",
                table: "HeadCircumferenceCheckups",
                column: "ChildHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_HearingPowerCheckups_ChildHealthId",
                table: "HearingPowerCheckups",
                column: "ChildHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_HearingPowerDetails_HearingPowerCheckupId",
                table: "HearingPowerDetails",
                column: "HearingPowerCheckupId");

            migrationBuilder.CreateIndex(
                name: "IX_KmpeCheckup_ChildHealthId",
                table: "KmpeCheckup",
                column: "ChildHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_KpspCheckups_ChildHealthId",
                table: "KpspCheckups",
                column: "ChildHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_M-ChatCheckup_ChildHealthId",
                table: "M-ChatCheckup",
                column: "ChildHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalStatusBbTbCheckups_ChildHealthId",
                table: "NutritionalStatusBbTbCheckups",
                column: "ChildHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalStatusImtUCheckups_ChildHealthId",
                table: "NutritionalStatusImtUCheckups",
                column: "ChildHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalStatusIpTbCheckups_ChildHealthId",
                table: "NutritionalStatusIpTbCheckups",
                column: "ChildHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_VisionCheckups_ChildHealthId",
                table: "VisionCheckups",
                column: "ChildHealthId");

            migrationBuilder.AddForeignKey(
                name: "FK_KpspDetails_KpspCheckups_KpspCheckupId",
                table: "KpspDetails",
                column: "KpspCheckupId",
                principalTable: "KpspCheckups",
                principalColumn: "KpspCheckupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KpspDetails_KpspCheckups_KpspCheckupId",
                table: "KpspDetails");

            migrationBuilder.DropTable(
                name: "BirthHistory");

            migrationBuilder.DropTable(
                name: "GpphCheckup");

            migrationBuilder.DropTable(
                name: "HeadCircumferenceCheckups");

            migrationBuilder.DropTable(
                name: "HearingPowerDetails");

            migrationBuilder.DropTable(
                name: "KmpeCheckup");

            migrationBuilder.DropTable(
                name: "KpspCheckups");

            migrationBuilder.DropTable(
                name: "M-ChatCheckup");

            migrationBuilder.DropTable(
                name: "NutritionalStatusBbTbCheckups");

            migrationBuilder.DropTable(
                name: "NutritionalStatusImtUCheckups");

            migrationBuilder.DropTable(
                name: "NutritionalStatusIpTbCheckups");

            migrationBuilder.DropTable(
                name: "ParentHistory");

            migrationBuilder.DropTable(
                name: "VisionCheckups");

            migrationBuilder.DropTable(
                name: "HearingPowerCheckups");

            migrationBuilder.DropTable(
                name: "ChildHealth");

            migrationBuilder.DropTable(
                name: "ChildDatas");

            migrationBuilder.RenameColumn(
                name: "KpspCheckupId",
                table: "KpspDetails",
                newName: "PemeriksaasnKpspId");

            migrationBuilder.RenameIndex(
                name: "IX_KpspDetails_KpspCheckupId",
                table: "KpspDetails",
                newName: "IX_KpspDetails_PemeriksaasnKpspId");

            migrationBuilder.CreateTable(
                name: "DataAnaks",
                columns: table => new
                {
                    DataAnakId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Alamat = table.Column<string>(type: "text", nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    JenisKelamin = table.Column<string>(type: "text", nullable: true),
                    JumlahSaudara = table.Column<byte>(type: "smallint", nullable: false),
                    Kontak = table.Column<string>(type: "text", nullable: true),
                    NIK = table.Column<int>(type: "integer", nullable: false),
                    NakesUserId = table.Column<int>(type: "integer", nullable: false),
                    NamaLengkap = table.Column<string>(type: "text", nullable: true),
                    TanggalLahirAnak = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataAnaks", x => x.DataAnakId);
                    table.ForeignKey(
                        name: "FK_DataAnaks_AspNetUsers_NakesUserId",
                        column: x => x.NakesUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KesehatanAnak",
                columns: table => new
                {
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataAnakId = table.Column<int>(type: "integer", nullable: false),
                    PemeriksaanBeratBadan = table.Column<int>(type: "integer", nullable: false),
                    PemeriksaanTinggiBadan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KesehatanAnak", x => x.KesehatanAnakId);
                    table.ForeignKey(
                        name: "FK_KesehatanAnak_DataAnaks_DataAnakId",
                        column: x => x.DataAnakId,
                        principalTable: "DataAnaks",
                        principalColumn: "DataAnakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiwayatKelahiran",
                columns: table => new
                {
                    RiwayatKelahiranId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApgarScore = table.Column<int>(type: "integer", nullable: false),
                    BeratBadan = table.Column<byte>(type: "smallint", nullable: false),
                    DataAnakId = table.Column<int>(type: "integer", nullable: false),
                    KelahiranDibantuOleh = table.Column<string>(type: "text", nullable: true),
                    LainLain = table.Column<string>(type: "text", nullable: true),
                    PanjangLahir = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiwayatKelahiran", x => x.RiwayatKelahiranId);
                    table.ForeignKey(
                        name: "FK_RiwayatKelahiran_DataAnaks_DataAnakId",
                        column: x => x.DataAnakId,
                        principalTable: "DataAnaks",
                        principalColumn: "DataAnakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiwayatOrangTua",
                columns: table => new
                {
                    RiwayatOrangTuaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnggotaRumahTangga = table.Column<byte>(type: "smallint", nullable: false),
                    DataAnakId = table.Column<int>(type: "integer", nullable: false),
                    NamaAyah = table.Column<string>(type: "text", nullable: true),
                    NamaIbu = table.Column<string>(type: "text", nullable: true),
                    PekerjaanAyah = table.Column<string>(type: "text", nullable: true),
                    PekerjaanIbu = table.Column<string>(type: "text", nullable: true),
                    PenghasilanOrangTua = table.Column<float>(type: "real", nullable: false),
                    TandaTanganPath = table.Column<string>(type: "text", nullable: true),
                    TanggalLahirAyah = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalLahirIbu = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiwayatOrangTua", x => x.RiwayatOrangTuaId);
                    table.ForeignKey(
                        name: "FK_RiwayatOrangTua_DataAnaks_DataAnakId",
                        column: x => x.DataAnakId,
                        principalTable: "DataAnaks",
                        principalColumn: "DataAnakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PemeriksaanDayaDengars",
                columns: table => new
                {
                    PemeriksaanDayaDengarId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PemeriksaanDayaDengars", x => x.PemeriksaanDayaDengarId);
                    table.ForeignKey(
                        name: "FK_PemeriksaanDayaDengars_KesehatanAnak_KesehatanAnakId",
                        column: x => x.KesehatanAnakId,
                        principalTable: "KesehatanAnak",
                        principalColumn: "KesehatanAnakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PemeriksaanDayaLihats",
                columns: table => new
                {
                    PemeriksaanDayaLihatId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false),
                    MataKanan = table.Column<int>(type: "integer", nullable: false),
                    MataKiri = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PemeriksaanDayaLihats", x => x.PemeriksaanDayaLihatId);
                    table.ForeignKey(
                        name: "FK_PemeriksaanDayaLihats_KesehatanAnak_KesehatanAnakId",
                        column: x => x.KesehatanAnakId,
                        principalTable: "KesehatanAnak",
                        principalColumn: "KesehatanAnakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PemeriksaanKesehatanGPPH",
                columns: table => new
                {
                    PemeriksaanGpphId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false),
                    Point = table.Column<byte>(type: "smallint", nullable: false),
                    Question1 = table.Column<byte>(type: "smallint", nullable: false),
                    Question10 = table.Column<byte>(type: "smallint", nullable: false),
                    Question2 = table.Column<byte>(type: "smallint", nullable: false),
                    Question3 = table.Column<byte>(type: "smallint", nullable: false),
                    Question4 = table.Column<byte>(type: "smallint", nullable: false),
                    Question5 = table.Column<byte>(type: "smallint", nullable: false),
                    Question6 = table.Column<byte>(type: "smallint", nullable: false),
                    Question7 = table.Column<byte>(type: "smallint", nullable: false),
                    Question8 = table.Column<byte>(type: "smallint", nullable: false),
                    Question9 = table.Column<byte>(type: "smallint", nullable: false)
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
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    JumlahYa = table.Column<byte>(type: "smallint", nullable: false),
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false),
                    Question1 = table.Column<bool>(type: "boolean", nullable: false),
                    Question10 = table.Column<bool>(type: "boolean", nullable: false),
                    Question11 = table.Column<bool>(type: "boolean", nullable: false),
                    Question12 = table.Column<bool>(type: "boolean", nullable: false),
                    Question13 = table.Column<bool>(type: "boolean", nullable: false),
                    Question14 = table.Column<bool>(type: "boolean", nullable: false),
                    Question2 = table.Column<bool>(type: "boolean", nullable: false),
                    Question3 = table.Column<bool>(type: "boolean", nullable: false),
                    Question4 = table.Column<bool>(type: "boolean", nullable: false),
                    Question5 = table.Column<bool>(type: "boolean", nullable: false),
                    Question6 = table.Column<bool>(type: "boolean", nullable: false),
                    Question7 = table.Column<bool>(type: "boolean", nullable: false),
                    Question8 = table.Column<bool>(type: "boolean", nullable: false),
                    Question9 = table.Column<bool>(type: "boolean", nullable: false)
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
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false),
                    Question1 = table.Column<bool>(type: "boolean", nullable: false),
                    Question10 = table.Column<bool>(type: "boolean", nullable: false),
                    Question11 = table.Column<bool>(type: "boolean", nullable: false),
                    Question12 = table.Column<bool>(type: "boolean", nullable: false),
                    Question13 = table.Column<bool>(type: "boolean", nullable: false),
                    Question14 = table.Column<bool>(type: "boolean", nullable: false),
                    Question15 = table.Column<bool>(type: "boolean", nullable: false),
                    Question16 = table.Column<bool>(type: "boolean", nullable: false),
                    Question17 = table.Column<bool>(type: "boolean", nullable: false),
                    Question18 = table.Column<bool>(type: "boolean", nullable: false),
                    Question19 = table.Column<bool>(type: "boolean", nullable: false),
                    Question2 = table.Column<bool>(type: "boolean", nullable: false),
                    Question20 = table.Column<bool>(type: "boolean", nullable: false),
                    Question21 = table.Column<bool>(type: "boolean", nullable: false),
                    Question22 = table.Column<bool>(type: "boolean", nullable: false),
                    Question23 = table.Column<bool>(type: "boolean", nullable: false),
                    Question3 = table.Column<bool>(type: "boolean", nullable: false),
                    Question4 = table.Column<bool>(type: "boolean", nullable: false),
                    Question5 = table.Column<bool>(type: "boolean", nullable: false),
                    Question6 = table.Column<bool>(type: "boolean", nullable: false),
                    Question7 = table.Column<bool>(type: "boolean", nullable: false),
                    Question8 = table.Column<bool>(type: "boolean", nullable: false),
                    Question9 = table.Column<bool>(type: "boolean", nullable: false),
                    TotalCriticalQuestionNo = table.Column<int>(type: "integer", nullable: false),
                    TotalCriticalQuestionYes = table.Column<int>(type: "integer", nullable: false),
                    TotalQuestionNo = table.Column<int>(type: "integer", nullable: false),
                    TotalQuestionYes = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "PemeriksaanKpsps",
                columns: table => new
                {
                    PemeriksaanKpspId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PemeriksaanKpsps", x => x.PemeriksaanKpspId);
                    table.ForeignKey(
                        name: "FK_PemeriksaanKpsps_KesehatanAnak_KesehatanAnakId",
                        column: x => x.KesehatanAnakId,
                        principalTable: "KesehatanAnak",
                        principalColumn: "KesehatanAnakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PemeriksaanLingkarKepalas",
                columns: table => new
                {
                    PemeriksaanLingkarKepalaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false),
                    Klasifikasi = table.Column<string>(type: "text", nullable: true),
                    Kurva = table.Column<int>(type: "integer", nullable: false),
                    LingkarKepala = table.Column<int>(type: "integer", nullable: false),
                    Tindakan = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PemeriksaanLingkarKepalas", x => x.PemeriksaanLingkarKepalaId);
                    table.ForeignKey(
                        name: "FK_PemeriksaanLingkarKepalas_KesehatanAnak_KesehatanAnakId",
                        column: x => x.KesehatanAnakId,
                        principalTable: "KesehatanAnak",
                        principalColumn: "KesehatanAnakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PemeriksaanStatusGiziBbTbs",
                columns: table => new
                {
                    PemeriksaanStatusGiziBbTbId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BeratBadan = table.Column<int>(type: "integer", nullable: false),
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false),
                    StatusGizi = table.Column<string>(type: "text", nullable: true),
                    Tindakan = table.Column<string>(type: "text", nullable: true),
                    TinggiBadan = table.Column<int>(type: "integer", nullable: false),
                    ZCode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PemeriksaanStatusGiziBbTbs", x => x.PemeriksaanStatusGiziBbTbId);
                    table.ForeignKey(
                        name: "FK_PemeriksaanStatusGiziBbTbs_KesehatanAnak_KesehatanAnakId",
                        column: x => x.KesehatanAnakId,
                        principalTable: "KesehatanAnak",
                        principalColumn: "KesehatanAnakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PemeriksaanStatusGiziImtUs",
                columns: table => new
                {
                    PemeriksaanStatusGiziImtUId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BeratBadan = table.Column<int>(type: "integer", nullable: false),
                    IMT = table.Column<int>(type: "integer", nullable: false),
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false),
                    StatusGizi = table.Column<string>(type: "text", nullable: true),
                    Tindakan = table.Column<string>(type: "text", nullable: true),
                    TinggiBadan = table.Column<int>(type: "integer", nullable: false),
                    Umur = table.Column<int>(type: "integer", nullable: false),
                    ZCode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PemeriksaanStatusGiziImtUs", x => x.PemeriksaanStatusGiziImtUId);
                    table.ForeignKey(
                        name: "FK_PemeriksaanStatusGiziImtUs_KesehatanAnak_KesehatanAnakId",
                        column: x => x.KesehatanAnakId,
                        principalTable: "KesehatanAnak",
                        principalColumn: "KesehatanAnakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PemeriksaanStatusGiziIpTbs",
                columns: table => new
                {
                    PemeriksaanStatusGiziIpTbId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IndeksPanjang = table.Column<int>(type: "integer", nullable: false),
                    KesehatanAnakId = table.Column<int>(type: "integer", nullable: false),
                    StatusGizi = table.Column<string>(type: "text", nullable: true),
                    Tindakan = table.Column<string>(type: "text", nullable: true),
                    TinggiBadan = table.Column<int>(type: "integer", nullable: false),
                    ZCode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PemeriksaanStatusGiziIpTbs", x => x.PemeriksaanStatusGiziIpTbId);
                    table.ForeignKey(
                        name: "FK_PemeriksaanStatusGiziIpTbs_KesehatanAnak_KesehatanAnakId",
                        column: x => x.KesehatanAnakId,
                        principalTable: "KesehatanAnak",
                        principalColumn: "KesehatanAnakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayaDengarDetails",
                columns: table => new
                {
                    DayaDengarDetailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Interpretasi = table.Column<string>(type: "text", nullable: true),
                    Intervensi = table.Column<string>(type: "text", nullable: true),
                    JumlahYa = table.Column<int>(type: "integer", nullable: false),
                    PemeriksaanDayaDengarId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayaDengarDetails", x => x.DayaDengarDetailId);
                    table.ForeignKey(
                        name: "FK_DayaDengarDetails_PemeriksaanDayaDengars_PemeriksaanDayaDen~",
                        column: x => x.PemeriksaanDayaDengarId,
                        principalTable: "PemeriksaanDayaDengars",
                        principalColumn: "PemeriksaanDayaDengarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataAnaks_NakesUserId",
                table: "DataAnaks",
                column: "NakesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DayaDengarDetails_PemeriksaanDayaDengarId",
                table: "DayaDengarDetails",
                column: "PemeriksaanDayaDengarId");

            migrationBuilder.CreateIndex(
                name: "IX_KesehatanAnak_DataAnakId",
                table: "KesehatanAnak",
                column: "DataAnakId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PemeriksaanDayaDengars_KesehatanAnakId",
                table: "PemeriksaanDayaDengars",
                column: "KesehatanAnakId");

            migrationBuilder.CreateIndex(
                name: "IX_PemeriksaanDayaLihats_KesehatanAnakId",
                table: "PemeriksaanDayaLihats",
                column: "KesehatanAnakId");

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

            migrationBuilder.CreateIndex(
                name: "IX_PemeriksaanKpsps_KesehatanAnakId",
                table: "PemeriksaanKpsps",
                column: "KesehatanAnakId");

            migrationBuilder.CreateIndex(
                name: "IX_PemeriksaanLingkarKepalas_KesehatanAnakId",
                table: "PemeriksaanLingkarKepalas",
                column: "KesehatanAnakId");

            migrationBuilder.CreateIndex(
                name: "IX_PemeriksaanStatusGiziBbTbs_KesehatanAnakId",
                table: "PemeriksaanStatusGiziBbTbs",
                column: "KesehatanAnakId");

            migrationBuilder.CreateIndex(
                name: "IX_PemeriksaanStatusGiziImtUs_KesehatanAnakId",
                table: "PemeriksaanStatusGiziImtUs",
                column: "KesehatanAnakId");

            migrationBuilder.CreateIndex(
                name: "IX_PemeriksaanStatusGiziIpTbs_KesehatanAnakId",
                table: "PemeriksaanStatusGiziIpTbs",
                column: "KesehatanAnakId");

            migrationBuilder.CreateIndex(
                name: "IX_RiwayatKelahiran_DataAnakId",
                table: "RiwayatKelahiran",
                column: "DataAnakId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RiwayatOrangTua_DataAnakId",
                table: "RiwayatOrangTua",
                column: "DataAnakId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KpspDetails_PemeriksaanKpsps_PemeriksaasnKpspId",
                table: "KpspDetails",
                column: "PemeriksaasnKpspId",
                principalTable: "PemeriksaanKpsps",
                principalColumn: "PemeriksaanKpspId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
