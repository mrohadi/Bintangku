using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Bintangku.WebApi.Data.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; } 
    }
}