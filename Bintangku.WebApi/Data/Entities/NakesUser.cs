using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Bintangku.WebApi.Data.Entities
{
    public class NakesUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long NoStrTenagaKesehatan { get; set; }
        public string TempatPelayanan { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;

        public ICollection<Photo> Photos { get; set; }
        public ICollection<ChildData> DataAnaks { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; } 
    }
}