using Microsoft.EntityFrameworkCore;
using Bintangku.Data.Entities;

namespace Bintangku.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }

        public DbSet<NakesUser> NakesUsers { get; set; }
        public DbSet<DataAnak> DataAnaks { get; set; }
        public DbSet<RiwayatKelahiran> RiwayatKelahirans { get; set; }
        public DbSet<RiwayatOrangTua> RiwayatOrangTuas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NakesUser>()
                .HasKey(b => b.Id);
            
            modelBuilder.Entity<DataAnak>()
                .HasKey(b => b.Id);
            
            modelBuilder.Entity<DataAnak>()
                .HasOne(n => n.NakesUser)
                .WithMany(a => a.DataAnaks)
                .HasForeignKey(n => n.NakesUserId);
            
            modelBuilder.Entity<DataAnak>()
                .HasOne<RiwayatKelahiran>(r => r.RiwayatKelahiran)
                .WithOne(d => d.DataAnak)
                .HasForeignKey<RiwayatKelahiran>(r => r.Id);

            modelBuilder.Entity<DataAnak>()
                .HasOne<RiwayatOrangTua>(r => r.RiwayatOrangTua)
                .WithOne(d => d.DataAnak)
                .HasForeignKey<RiwayatOrangTua>(r => r.Id);
        }
    }
}