using Microsoft.AspNetCore.Identity;

namespace Bintangku.Data.Entities
{
    // Join table between User and role
    public class AppUserRole : IdentityUserRole<int> 
    {
        public NakesUser User { get; set; }
        public AppRole Role { get; set; }
    }
}