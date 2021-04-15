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

        public DbSet<ChildData> ChildDatas { get; set; }
        public DbSet<BirthHistory> BirthHistories { get; set; }
        public DbSet<ParentHistory> ParentHistories { get; set; }
        public DbSet<ChildHealth> ChildHealths { get; set; }
        public DbSet<GpphCheckup> GpphCheckups { get; set; }
        public DbSet<MchatCheckup> MchatCheckups { get; set; }
        public DbSet<KmpeCheckup> KmpeCheckups { get; set; }
        public DbSet<HearingPowerCheckup> HearingPowerCheckups { get; set; }
        public DbSet<VisionCheckup> VisionCheckups { get; set; }
        public DbSet<NutritionalStatusBbTbCheckup> NutritionalStatusBbTbCheckups { get; set; }
        public DbSet<NutritionalStatusImtUCheckup> NutritionalStatusImtUCheckups { get; set; }
        public DbSet<NutritionalStatusIpTbCheckup> NutritionalStatusIpTbCheckups { get; set; }
        public DbSet<HeadCircumferenceCheckup> HeadCircumferenceCheckups { get; set; }
        public DbSet<KpspCheckup> KpspCheckups { get; set; }
        public DbSet<KpspDetail> KpspDetails { get; set; }
        public DbSet<HearingPowerDetail> HearingPowerDetails { get; set; }

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

            modelBuilder.Entity<ChildData>()
                .HasOne(nakes => nakes.NakesUser)
                .WithMany(anak => anak.DataAnaks)
                .HasForeignKey(nakes => nakes.NakesUserId);
            
            modelBuilder.Entity<ChildData>()
                .HasOne(birth => birth.BirthHistory)
                .WithOne(child => child.ChildData)
                .HasForeignKey<BirthHistory>(birth => birth.BirthHistoryId);
            
            modelBuilder.Entity<ChildData>()
                .HasOne(parent => parent.ParentHistory)
                .WithOne(child => child.ChildData)
                .HasForeignKey<ParentHistory>(parent => parent.ParentHistoryId);
            
            modelBuilder.Entity<ChildData>()
                .HasOne(health => health.ChildHealth)
                .WithOne(child => child.ChildData)
                .HasForeignKey<ChildHealth>(health => health.ChildDataId);
            
            // Pemeriksaan Foreign Key to Kesehatan Anak Configuration
            modelBuilder.Entity<GpphCheckup>()
                .HasOne(health => health.ChildHealth)
                .WithMany(check => check.GpphCheckups)
                .HasForeignKey(health => health.ChildHealthId);
            
            modelBuilder.Entity<MchatCheckup>()
                .HasOne(health => health.ChildHealth)
                .WithMany(check => check.MchatCheckups)
                .HasForeignKey(health => health.ChildHealthId);
            
            modelBuilder.Entity<KmpeCheckup>()
                .HasOne(health => health.ChildHealth)
                .WithMany(check => check.KmpeCheckups)
                .HasForeignKey(health => health.ChildHealthId);
            
            modelBuilder.Entity<HearingPowerCheckup>()
                .HasOne(health => health.ChildHealth)
                .WithMany(check => check.hearingPowerCheckups)
                .HasForeignKey(health => health.ChildHealthId);
            
            modelBuilder.Entity<VisionCheckup>()
                .HasOne(health => health.ChildHealth)
                .WithMany(check => check.VisionCheckups)
                .HasForeignKey(health => health.ChildHealthId);
            
            modelBuilder.Entity<NutritionalStatusBbTbCheckup>()
                .HasOne(health => health.ChildHealth)
                .WithMany(check => check.NutritionalStatusBbTbCheckups)
                .HasForeignKey(health => health.ChildHealthId);
            
            modelBuilder.Entity<NutritionalStatusImtUCheckup>()
                .HasOne(health => health.ChildHealth)
                .WithMany(check => check.NutritionalStatusImtUCheckups)
                .HasForeignKey(health => health.ChildHealthId);

            modelBuilder.Entity<NutritionalStatusIpTbCheckup>()
                .HasOne(health => health.ChildHealth)
                .WithMany(check => check.NutritionalStatusIpTbCheckups)
                .HasForeignKey(health => health.ChildHealthId);
            
            modelBuilder.Entity<HeadCircumferenceCheckup>()
                .HasOne(health => health.ChildHealth)
                .WithMany(check => check.HeadCircumferenceCheckups)
                .HasForeignKey(health => health.ChildHealthId);

            modelBuilder.Entity<KpspCheckup>()
                .HasOne(health => health.ChildHealth)
                .WithMany(check => check.KpspCheckups)
                .HasForeignKey(health => health.ChildHealthId);

            modelBuilder.Entity<KpspDetail>()
                .HasOne(kpsp => kpsp.KpspCheckup)
                .WithMany(detail => detail.KpspDetails)
                .HasForeignKey(kpsp => kpsp.KpspCheckupId);
            
            modelBuilder.Entity<HearingPowerDetail>()
                .HasOne(check => check.HearingPowerCheckup)
                .WithMany(detail => detail.HearingPowerDetails)
                .HasForeignKey(hear => hear.HearingPowerCheckupId);

        }
    }
}