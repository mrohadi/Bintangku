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
        public static async Task SeedNakesUser(UserManager<NakesUser> userManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var nakesUserData = await File.ReadAllTextAsync(
                "../Bintangku.Data/NakesUserSeedData.json");
            var users = JsonSerializer.Deserialize<List<NakesUser>>(nakesUserData);
            if (users == null) return;
            
            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}