using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Bintangku.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.Data
{
    public static class DataSeed
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task SeedNakesUser(
            UserManager<NakesUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var nakesUserData = await File.ReadAllTextAsync(
                "../Bintangku.Data/NakesUserSeedData.json");
            var users = JsonSerializer.Deserialize<List<NakesUser>>(nakesUserData);
            if (users == null) return;
            
            var roles = new List<AppRole>
            {
                new AppRole { Name = "Nakes" },
                new AppRole { Name = "Puskesmas" },
                new AppRole { Name = "Admin" },
            };
            
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role); 
            }
            
            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Nakes");
            }
            
            var admin = new NakesUser
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd"); 
            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Puskesmas" });
        }
    }
}