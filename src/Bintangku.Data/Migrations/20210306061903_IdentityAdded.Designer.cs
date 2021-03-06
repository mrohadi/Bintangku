﻿// <auto-generated />
using System;
using Bintangku.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bintangku.Data.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20210306061903_IdentityAdded")]
    partial class IdentityAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Bintangku.Data.Entities.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Bintangku.Data.Entities.AppUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Bintangku.Data.Entities.DataAnak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alamat")
                        .HasColumnType("TEXT");

                    b.Property<string>("JenisKelamin")
                        .HasColumnType("TEXT");

                    b.Property<byte>("JumlahSaudara")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kontak")
                        .HasColumnType("TEXT");

                    b.Property<int>("NIK")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NamaLengkap")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoAnakUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TanggalLahirAnak")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DataAnaks");
                });

            modelBuilder.Entity("Bintangku.Data.Entities.NakesUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<long>("NoStrTenagaKesehatan")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("TempatPelayanan")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Bintangku.Data.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NakesUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NakesUserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Bintangku.Data.Entities.RiwayatKelahiran", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApgarScore")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("BeratBadan")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DataAnakId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("KelahiranDibantuOleh")
                        .HasColumnType("TEXT");

                    b.Property<string>("LainLain")
                        .HasColumnType("TEXT");

                    b.Property<int>("PanjangLahir")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("RiwayatKelahirans");
                });

            modelBuilder.Entity("Bintangku.Data.Entities.RiwayatOrangTua", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("AnggotaRumahTangga")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DataAnakId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NamaAyah")
                        .HasColumnType("TEXT");

                    b.Property<string>("NamaIbu")
                        .HasColumnType("TEXT");

                    b.Property<string>("PekerjaanAyah")
                        .HasColumnType("TEXT");

                    b.Property<string>("PekerjaanIbu")
                        .HasColumnType("TEXT");

                    b.Property<float>("PenghasilanOrangTua")
                        .HasColumnType("REAL");

                    b.Property<string>("TandaTanganOrangTua")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TanggalLahirAyah")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TanggalLahirIbu")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RiwayatOrangTuas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Bintangku.Data.Entities.AppUserRole", b =>
                {
                    b.HasOne("Bintangku.Data.Entities.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bintangku.Data.Entities.NakesUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bintangku.Data.Entities.DataAnak", b =>
                {
                    b.HasOne("Bintangku.Data.Entities.NakesUser", "NakesUser")
                        .WithMany("DataAnaks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NakesUser");
                });

            modelBuilder.Entity("Bintangku.Data.Entities.Photo", b =>
                {
                    b.HasOne("Bintangku.Data.Entities.NakesUser", "NakesUser")
                        .WithMany("Photos")
                        .HasForeignKey("NakesUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NakesUser");
                });

            modelBuilder.Entity("Bintangku.Data.Entities.RiwayatKelahiran", b =>
                {
                    b.HasOne("Bintangku.Data.Entities.DataAnak", "DataAnak")
                        .WithOne("RiwayatKelahiran")
                        .HasForeignKey("Bintangku.Data.Entities.RiwayatKelahiran", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataAnak");
                });

            modelBuilder.Entity("Bintangku.Data.Entities.RiwayatOrangTua", b =>
                {
                    b.HasOne("Bintangku.Data.Entities.DataAnak", "DataAnak")
                        .WithOne("RiwayatOrangTua")
                        .HasForeignKey("Bintangku.Data.Entities.RiwayatOrangTua", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataAnak");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Bintangku.Data.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Bintangku.Data.Entities.NakesUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Bintangku.Data.Entities.NakesUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Bintangku.Data.Entities.NakesUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bintangku.Data.Entities.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Bintangku.Data.Entities.DataAnak", b =>
                {
                    b.Navigation("RiwayatKelahiran");

                    b.Navigation("RiwayatOrangTua");
                });

            modelBuilder.Entity("Bintangku.Data.Entities.NakesUser", b =>
                {
                    b.Navigation("DataAnaks");

                    b.Navigation("Photos");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
