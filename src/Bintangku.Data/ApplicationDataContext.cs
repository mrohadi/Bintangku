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
    }
}