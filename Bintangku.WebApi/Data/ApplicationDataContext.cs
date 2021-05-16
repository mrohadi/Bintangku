using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Data.Entities.Imunisasi;
using Bintangku.WebApi.Data.Entities.Pemeriksaan;

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
        public DbSet<PemeriksaanDayaDengar> PemeriksaanDayaDengars { get; set; }
        public DbSet<PemeriksaanDayaLihat> PemeriksaanDayaLihats { get; set; }
        public DbSet<PemeriksaanStatusGiziBbTb> PemeriksaanStatusGiziBbTbs { get; set; }
        public DbSet<PemeriksaanStatusGiziImtU> PemeriksaanStatusGiziImtUs { get; set; }
        public DbSet<PemeriksaanStatusGiziIpTb> PemeriksaanStatusGiziIpTbs { get; set; }
        public DbSet<PemeriksaanLingkarKepala> PemeriksaanLingkarKepalas { get; set; }
        public DbSet<PemeriksaanKpsp> PemeriksaanKpsps { get; set; }

        public DbSet<ImunisasiAnak> ImunisasiAnaks { get; set; }
        public DbSet<ImunisasiHepatitisB> ImunisasiHepatitisBs { get; set; }
        public DbSet<ImunisasiPolio> ImunisasiPolios { get; set; }
        public DbSet<ImunisasiBCG> ImunisasiBCGs { get; set; }
        public DbSet<ImunisasiDTP> ImunisasiDTPs { get; set; }
        public DbSet<ImunisasiHib> ImunisasiHibs { get; set; }
        public DbSet<ImunisasiPCV> ImunisasiPCVs { get; set; }
        public DbSet<ImunisasiRotavirus> ImunisasiRotaviruses { get; set; }
        public DbSet<ImunisasiInfluenza> ImunisasiInfluenzas { get; set; }
        public DbSet<ImunisasiCampak> ImunisasiCampaks { get; set; }
        public DbSet<ImunisasiMMR> ImunisasiMMRs { get; set; }
        public DbSet<ImunisasiTifoid> ImunisasiTifoids { get; set; }
        public DbSet<ImunisasiHepatitisA> ImunisasiHepatitisAs { get; set; }
        public DbSet<ImunisasiVarisela> ImunisasiVariselas { get; set; }
        public DbSet<ImunisasiHPV> ImunisasiHPVs { get; set; }
        public DbSet<ImunisasiJapaneseEncephalitis> ImunisasiJapaneseEncephalitis { get; set; }
        public DbSet<ImunisasiDengue> ImunisasiDengues { get; set; }

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
            
            modelBuilder.Entity<PemeriksaanDayaDengar>()
                .HasOne(kesehatan => kesehatan.KesehatanAnak)
                .WithMany(pemeriksaan => pemeriksaan.PemeriksaanDayaDengars)
                .HasForeignKey(kesehatan => kesehatan.KesehatanAnakId);
            
            modelBuilder.Entity<PemeriksaanDayaLihat>()
                .HasOne(kesehatan => kesehatan.KesehatanAnak)
                .WithMany(pemeriksaan => pemeriksaan.PemeriksaanDayaLihats)
                .HasForeignKey(kesehatan => kesehatan.KesehatanAnakId);
            
            modelBuilder.Entity<PemeriksaanStatusGiziBbTb>()
                .HasOne(kesehatan => kesehatan.KesehatanAnak)
                .WithMany(pemeriksaan => pemeriksaan.PemeriksaanStatusGiziBbTbs)
                .HasForeignKey(kesehatan => kesehatan.KesehatanAnakId);
            
            modelBuilder.Entity<PemeriksaanStatusGiziImtU>()
                .HasOne(kesehatan => kesehatan.KesehatanAnak)
                .WithMany(pemeriksaan => pemeriksaan.PemeriksaanStatusGiziImtUs)
                .HasForeignKey(kesehatan => kesehatan.KesehatanAnakId);

            modelBuilder.Entity<PemeriksaanStatusGiziIpTb>()
                .HasOne(kesehatan => kesehatan.KesehatanAnak)
                .WithMany(pemeriksaan => pemeriksaan.PemeriksaanStatusGiziIpTbs)
                .HasForeignKey(kesehatan => kesehatan.KesehatanAnakId);
            
            modelBuilder.Entity<PemeriksaanLingkarKepala>()
                .HasOne(kesehatan => kesehatan.KesehatanAnak)
                .WithMany(pemeriksaan => pemeriksaan.PemeriksaanLingkarKepalas)
                .HasForeignKey(kesehatan => kesehatan.KesehatanAnakId);

            modelBuilder.Entity<PemeriksaanKpsp>()
                .HasOne(kesehatan => kesehatan.KesehatanAnak)
                .WithMany(pemeriksaan => pemeriksaan.PemeriksaanKpsps)
                .HasForeignKey(kesehatan => kesehatan.KesehatanAnakId);

        }
    }
}