using Microsoft.EntityFrameworkCore;
using Bintangku.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Bintangku.Data
{
    public class ApplicationDataContext : IdentityDbContext<NakesUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }

        public DbSet<DataAnak> DataAnaks { get; set; }

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
                .HasKey(b => b.Id);
            
            modelBuilder.Entity<DataAnak>()
                .HasOne(n => n.NakesUser)
                .WithMany(a => a.DataAnaks)
                .HasForeignKey(n => n.UserId);
            
            // modelBuilder.Entity<DataAnak>()
            //     .HasOne<RiwayatKelahiran>(r => r.RiwayatKelahiran)
            //     .WithOne(d => d.DataAnak)
            //     .HasForeignKey<RiwayatKelahiran>(r => r.Id);

            // modelBuilder.Entity<DataAnak>()
            //     .HasOne<RiwayatOrangTua>(r => r.RiwayatOrangTua)
            //     .WithOne(d => d.DataAnak)
            //     .HasForeignKey<RiwayatOrangTua>(r => r.Id);
                
            // modelBuilder.Entity<DataAnak>()
            //     .HasOne<KesehatanAnak>(k => k.KesehatanAnak)
            //     .WithOne(d => d.DataAnak)
            //     .HasForeignKey<KesehatanAnak>(k => k.Id);
        }
    }
}