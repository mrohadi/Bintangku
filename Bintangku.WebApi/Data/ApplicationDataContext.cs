using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Data
{
    public class ApplicationDataContext : IdentityDbContext<NakesUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }

        public DbSet<DataAnak> DataAnaks { get; set; }
        public DbSet<RiwayatKelahiran> RiwayatKelahirans { get; set; }
        public DbSet<RiwayatOrangTua> RiwayatOrangTuas { get; set; }
        public DbSet<KesehatanAnak> KesehatanAnaks { get; set; }
        public DbSet<PemeriksaanGpph> PemeriksaanGpphs { get; set; }
        public DbSet<PemeriksaanMchat> PemeriksaanMchats { get; set; }
        public DbSet<PemeriksaanKmpe> PemeriksaanKmpes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NakesUser>()
                .HasMany(ur => ur.UserRoles )
                .WithOne(u => u.User) 
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles )
                .WithOne(u => u.Role) 
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            modelBuilder.Entity<NakesUser>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<DataAnak>()
                .HasOne(nakes => nakes.NakesUser)
                .WithMany(anak => anak.DataAnaks)
                .HasForeignKey(nakes => nakes.NakesUserId);
            
            modelBuilder.Entity<DataAnak>()
                .HasOne(kelahiran => kelahiran.RiwayatKelahiran)
                .WithOne(anak => anak.DataAnak)
                .HasForeignKey<RiwayatKelahiran>(kelahiran => kelahiran.DataAnakId);
            
            modelBuilder.Entity<DataAnak>()
                .HasOne(orangTua => orangTua.RiwayatOrangTua)
                .WithOne(anak => anak.DataAnak)
                .HasForeignKey<RiwayatOrangTua>(orangTua => orangTua.DataAnakId);
            
            modelBuilder.Entity<DataAnak>()
                .HasOne(kesehatan => kesehatan.KesehatanAnak)
                .WithOne(anak => anak.DataAnak)
                .HasForeignKey<KesehatanAnak>(kesehatan => kesehatan.DataAnakId);
            
            // Pemeriksaan Foreign Key to Kesehatan Anak Configuration
            modelBuilder.Entity<PemeriksaanGpph>()
                .HasOne(kesehatan => kesehatan.KesehatanAnak)
                .WithMany(pemeriksaan => pemeriksaan.PemeriksaanGpphs)
                .HasForeignKey(kesehatan => kesehatan.KesehatanAnakId);
            
            modelBuilder.Entity<PemeriksaanMchat>()
                .HasOne(kesehatan => kesehatan.KesehatanAnak)
                .WithMany(pemeriksaan => pemeriksaan.PemeriksaanMchats)
                .HasForeignKey(kesehatan => kesehatan.KesehatanAnakId);
            
            modelBuilder.Entity<PemeriksaanKmpe>()
                .HasOne(kesehatan => kesehatan.KesehatanAnak)
                .WithMany(pemeriksaan => pemeriksaan.PemeriksaanKmpes)
                .HasForeignKey(kesehatan => kesehatan.KesehatanAnakId);
        }
    }
}