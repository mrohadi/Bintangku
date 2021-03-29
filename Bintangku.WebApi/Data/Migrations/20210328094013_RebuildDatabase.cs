﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bintangku.WebApi.Data.Migrations
{
    public partial class RebuildDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NoStrTenagaKesehatan = table.Column<long>(type: "bigint", nullable: false),
                    TempatPelayanan = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastActive = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataAnaks",
                columns: table => new
                {
                    DataAnakId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaLengkap = table.Column<string>(type: "text", nullable: true),
                    NIK = table.Column<int>(type: "integer", nullable: false),
                    JenisKelamin = table.Column<string>(type: "text", nullable: true),
                    TanggalLahirAnak = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: true),
                    Kontak = table.Column<string>(type: "text", nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    JumlahSaudara = table.Column<byte>(type: "smallint", nullable: false),
                    NakesUserId = table.Column<int>(type: "integer", nullable: false)
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
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: true),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false),
                    PublicId = table.Column<string>(type: "text", nullable: true),
                    NakesUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AspNetUsers_NakesUserId",
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
                    PemeriksaanBeratBadan = table.Column<int>(type: "integer", nullable: false),
                    PemeriksaanTinggiBadan = table.Column<int>(type: "integer", nullable: false),
                    Imt = table.Column<int>(type: "integer", nullable: false),
                    LingkarKepala = table.Column<string>(type: "text", nullable: true),
                    StatusGiziBbTb = table.Column<string>(type: "text", nullable: true),
                    StatusGiziImtU = table.Column<string>(type: "text", nullable: true),
                    StatusGiziIpTb = table.Column<string>(type: "text", nullable: true),
                    Kpsp = table.Column<string>(type: "text", nullable: true),
                    DayaDengar = table.Column<string>(type: "text", nullable: true),
                    DayaLihat = table.Column<string>(type: "text", nullable: true),
                    Kmpe = table.Column<string>(type: "text", nullable: true),
                    Mchat = table.Column<string>(type: "text", nullable: true),
                    Gpph = table.Column<string>(type: "text", nullable: true),
                    DataAnakId = table.Column<int>(type: "integer", nullable: false)
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
                    BeratBadan = table.Column<byte>(type: "smallint", nullable: false),
                    PanjangLahir = table.Column<int>(type: "integer", nullable: false),
                    ApgarScore = table.Column<int>(type: "integer", nullable: false),
                    KelahiranDibantuOleh = table.Column<string>(type: "text", nullable: true),
                    LainLain = table.Column<string>(type: "text", nullable: true),
                    DataAnakId = table.Column<int>(type: "integer", nullable: false)
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
                    NamaAyah = table.Column<string>(type: "text", nullable: true),
                    TanggalLahirAyah = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PekerjaanAyah = table.Column<string>(type: "text", nullable: true),
                    NamaIbu = table.Column<string>(type: "text", nullable: true),
                    TanggalLahirIbu = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PekerjaanIbu = table.Column<string>(type: "text", nullable: true),
                    PenghasilanOrangTua = table.Column<float>(type: "real", nullable: false),
                    AnggotaRumahTangga = table.Column<byte>(type: "smallint", nullable: false),
                    TandaTanganPath = table.Column<string>(type: "text", nullable: true),
                    DataAnakId = table.Column<int>(type: "integer", nullable: false)
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
                    Q = table.Column<bool>(type: "boolean", nullable: false),
                    R = table.Column<bool>(type: "boolean", nullable: false),
                    S = table.Column<bool>(type: "boolean", nullable: false),
                    T = table.Column<bool>(type: "boolean", nullable: false),
                    U = table.Column<bool>(type: "boolean", nullable: false),
                    V = table.Column<bool>(type: "boolean", nullable: false),
                    W = table.Column<bool>(type: "boolean", nullable: false),
                    PemeriksaanMchatId = table.Column<int>(type: "integer", nullable: false)
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataAnaks_NakesUserId",
                table: "DataAnaks",
                column: "NakesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_KesehatanAnak_DataAnakId",
                table: "KesehatanAnak",
                column: "DataAnakId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MChat_PemeriksaanMchatId",
                table: "MChat",
                column: "PemeriksaanMchatId");

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
                name: "IX_Photos_NakesUserId",
                table: "Photos",
                column: "NakesUserId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MChat");

            migrationBuilder.DropTable(
                name: "PemeriksaanKesehatanGPPH");

            migrationBuilder.DropTable(
                name: "PemeriksaanKesehatanKMPE");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "RiwayatKelahiran");

            migrationBuilder.DropTable(
                name: "RiwayatOrangTua");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PemeriksaanKesehatanM-CHAT");

            migrationBuilder.DropTable(
                name: "KesehatanAnak");

            migrationBuilder.DropTable(
                name: "DataAnaks");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}