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
        }
    }
}