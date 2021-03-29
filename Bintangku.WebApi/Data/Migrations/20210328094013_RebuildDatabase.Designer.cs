﻿// <auto-generated />
using System;
using Bintangku.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bintangku.WebApi.Data.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20210328094013_RebuildDatabase")]
    partial class RebuildDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.AppUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.DataAnak", b =>
                {
                    b.Property<int>("DataAnakId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Alamat")
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<string>("JenisKelamin")
                        .HasColumnType("text");

                    b.Property<byte>("JumlahSaudara")
                        .HasColumnType("smallint");

                    b.Property<string>("Kontak")
                        .HasColumnType("text");

                    b.Property<int>("NIK")
                        .HasColumnType("integer");

                    b.Property<int>("NakesUserId")
                        .HasColumnType("integer");

                    b.Property<string>("NamaLengkap")
                        .HasColumnType("text");

                    b.Property<DateTime>("TanggalLahirAnak")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("DataAnakId");

                    b.HasIndex("NakesUserId");

                    b.ToTable("DataAnaks");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.KesehatanAnak", b =>
                {
                    b.Property<int>("KesehatanAnakId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("DataAnakId")
                        .HasColumnType("integer");

                    b.Property<string>("DayaDengar")
                        .HasColumnType("text");

                    b.Property<string>("DayaLihat")
                        .HasColumnType("text");

                    b.Property<string>("Gpph")
                        .HasColumnType("text");

                    b.Property<int>("Imt")
                        .HasColumnType("integer");

                    b.Property<string>("Kmpe")
                        .HasColumnType("text");

                    b.Property<string>("Kpsp")
                        .HasColumnType("text");

                    b.Property<string>("LingkarKepala")
                        .HasColumnType("text");

                    b.Property<string>("Mchat")
                        .HasColumnType("text");

                    b.Property<int>("PemeriksaanBeratBadan")
                        .HasColumnType("integer");

                    b.Property<int>("PemeriksaanTinggiBadan")
                        .HasColumnType("integer");

                    b.Property<string>("StatusGiziBbTb")
                        .HasColumnType("text");

                    b.Property<string>("StatusGiziImtU")
                        .HasColumnType("text");

                    b.Property<string>("StatusGiziIpTb")
                        .HasColumnType("text");

                    b.HasKey("KesehatanAnakId");

                    b.HasIndex("DataAnakId")
                        .IsUnique();

                    b.ToTable("KesehatanAnak");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.MChat", b =>
                {
                    b.Property<int>("MChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("A")
                        .HasColumnType("boolean");

                    b.Property<bool>("B")
                        .HasColumnType("boolean");

                    b.Property<bool>("C")
                        .HasColumnType("boolean");

                    b.Property<bool>("D")
                        .HasColumnType("boolean");

                    b.Property<bool>("E")
                        .HasColumnType("boolean");

                    b.Property<bool>("F")
                        .HasColumnType("boolean");

                    b.Property<bool>("G")
                        .HasColumnType("boolean");

                    b.Property<bool>("H")
                        .HasColumnType("boolean");

                    b.Property<bool>("I")
                        .HasColumnType("boolean");

                    b.Property<bool>("J")
                        .HasColumnType("boolean");

                    b.Property<bool>("K")
                        .HasColumnType("boolean");

                    b.Property<bool>("L")
                        .HasColumnType("boolean");

                    b.Property<bool>("M")
                        .HasColumnType("boolean");

                    b.Property<bool>("N")
                        .HasColumnType("boolean");

                    b.Property<bool>("O")
                        .HasColumnType("boolean");

                    b.Property<bool>("P")
                        .HasColumnType("boolean");

                    b.Property<int>("PemeriksaanMchatId")
                        .HasColumnType("integer");

                    b.Property<bool>("Q")
                        .HasColumnType("boolean");

                    b.Property<bool>("R")
                        .HasColumnType("boolean");

                    b.Property<bool>("S")
                        .HasColumnType("boolean");

                    b.Property<bool>("T")
                        .HasColumnType("boolean");

                    b.Property<bool>("U")
                        .HasColumnType("boolean");

                    b.Property<bool>("V")
                        .HasColumnType("boolean");

                    b.Property<bool>("W")
                        .HasColumnType("boolean");

                    b.HasKey("MChatId");

                    b.HasIndex("PemeriksaanMchatId");

                    b.ToTable("MChat");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.NakesUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("NoStrTenagaKesehatan")
                        .HasColumnType("bigint");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("TempatPelayanan")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.PemeriksaanGpph", b =>
                {
                    b.Property<int>("PemeriksaanGpphId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Interpretasi")
                        .HasColumnType("text");

                    b.Property<string>("Intervensi")
                        .HasColumnType("text");

                    b.Property<int>("KesehatanAnakId")
                        .HasColumnType("integer");

                    b.Property<byte>("Point")
                        .HasColumnType("smallint");

                    b.HasKey("PemeriksaanGpphId");

                    b.HasIndex("KesehatanAnakId");

                    b.ToTable("PemeriksaanKesehatanGPPH");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.PemeriksaanKmpe", b =>
                {
                    b.Property<int>("PemeriksaanKmpeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Interpretasi")
                        .HasColumnType("text");

                    b.Property<string>("Intervensi")
                        .HasColumnType("text");

                    b.Property<byte>("JumlahYa")
                        .HasColumnType("smallint");

                    b.Property<int>("KesehatanAnakId")
                        .HasColumnType("integer");

                    b.HasKey("PemeriksaanKmpeId");

                    b.HasIndex("KesehatanAnakId");

                    b.ToTable("PemeriksaanKesehatanKMPE");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.PemeriksaanMchat", b =>
                {
                    b.Property<int>("PemeriksaanMchatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Interpretasi")
                        .HasColumnType("text");

                    b.Property<string>("Intervensi")
                        .HasColumnType("text");

                    b.Property<int>("JumlahTidak")
                        .HasColumnType("integer");

                    b.Property<int>("JumlahYa")
                        .HasColumnType("integer");

                    b.Property<int>("KesehatanAnakId")
                        .HasColumnType("integer");

                    b.HasKey("PemeriksaanMchatId");

                    b.HasIndex("KesehatanAnakId");

                    b.ToTable("PemeriksaanKesehatanM-CHAT");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.Property<int>("NakesUserId")
                        .HasColumnType("integer");

                    b.Property<string>("PublicId")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NakesUserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.RiwayatKelahiran", b =>
                {
                    b.Property<int>("RiwayatKelahiranId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("ApgarScore")
                        .HasColumnType("integer");

                    b.Property<byte>("BeratBadan")
                        .HasColumnType("smallint");

                    b.Property<int>("DataAnakId")
                        .HasColumnType("integer");

                    b.Property<string>("KelahiranDibantuOleh")
                        .HasColumnType("text");

                    b.Property<string>("LainLain")
                        .HasColumnType("text");

                    b.Property<int>("PanjangLahir")
                        .HasColumnType("integer");

                    b.HasKey("RiwayatKelahiranId");

                    b.HasIndex("DataAnakId")
                        .IsUnique();

                    b.ToTable("RiwayatKelahiran");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.RiwayatOrangTua", b =>
                {
                    b.Property<int>("RiwayatOrangTuaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<byte>("AnggotaRumahTangga")
                        .HasColumnType("smallint");

                    b.Property<int>("DataAnakId")
                        .HasColumnType("integer");

                    b.Property<string>("NamaAyah")
                        .HasColumnType("text");

                    b.Property<string>("NamaIbu")
                        .HasColumnType("text");

                    b.Property<string>("PekerjaanAyah")
                        .HasColumnType("text");

                    b.Property<string>("PekerjaanIbu")
                        .HasColumnType("text");

                    b.Property<float>("PenghasilanOrangTua")
                        .HasColumnType("real");

                    b.Property<string>("TandaTanganPath")
                        .HasColumnType("text");

                    b.Property<DateTime>("TanggalLahirAyah")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TanggalLahirIbu")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("RiwayatOrangTuaId");

                    b.HasIndex("DataAnakId")
                        .IsUnique();

                    b.ToTable("RiwayatOrangTua");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.AppUserRole", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bintangku.WebApi.Data.Entities.NakesUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.DataAnak", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.NakesUser", "NakesUser")
                        .WithMany("DataAnaks")
                        .HasForeignKey("NakesUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NakesUser");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.KesehatanAnak", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.DataAnak", "DataAnak")
                        .WithOne("KesehatanAnak")
                        .HasForeignKey("Bintangku.WebApi.Data.Entities.KesehatanAnak", "DataAnakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataAnak");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.MChat", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.PemeriksaanMchat", "PemeriksaanMchat")
                        .WithMany("MChats")
                        .HasForeignKey("PemeriksaanMchatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PemeriksaanMchat");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.PemeriksaanGpph", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.KesehatanAnak", "KesehatanAnak")
                        .WithMany("PemeriksaanGpphs")
                        .HasForeignKey("KesehatanAnakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KesehatanAnak");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.PemeriksaanKmpe", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.KesehatanAnak", "KesehatanAnak")
                        .WithMany("PemeriksaanKmpes")
                        .HasForeignKey("KesehatanAnakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KesehatanAnak");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.PemeriksaanMchat", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.KesehatanAnak", "KesehatanAnak")
                        .WithMany("PemeriksaanMchats")
                        .HasForeignKey("KesehatanAnakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KesehatanAnak");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.Photo", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.NakesUser", "NakesUser")
                        .WithMany("Photos")
                        .HasForeignKey("NakesUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NakesUser");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.RiwayatKelahiran", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.DataAnak", "DataAnak")
                        .WithOne("RiwayatKelahiran")
                        .HasForeignKey("Bintangku.WebApi.Data.Entities.RiwayatKelahiran", "DataAnakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataAnak");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.RiwayatOrangTua", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.DataAnak", "DataAnak")
                        .WithOne("RiwayatOrangTua")
                        .HasForeignKey("Bintangku.WebApi.Data.Entities.RiwayatOrangTua", "DataAnakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataAnak");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.NakesUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.NakesUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Bintangku.WebApi.Data.Entities.NakesUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.DataAnak", b =>
                {
                    b.Navigation("KesehatanAnak");

                    b.Navigation("RiwayatKelahiran");

                    b.Navigation("RiwayatOrangTua");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.KesehatanAnak", b =>
                {
                    b.Navigation("PemeriksaanGpphs");

                    b.Navigation("PemeriksaanKmpes");

                    b.Navigation("PemeriksaanMchats");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.NakesUser", b =>
                {
                    b.Navigation("DataAnaks");

                    b.Navigation("Photos");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Bintangku.WebApi.Data.Entities.PemeriksaanMchat", b =>
                {
                    b.Navigation("MChats");
                });
#pragma warning restore 612, 618
        }
    }
}
