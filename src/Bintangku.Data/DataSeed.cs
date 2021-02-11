using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Bintangku.Data.Entities;
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
        public static async Task SeedNakesUser(ApplicationDataContext context)
        {
            if (await context.NakesUsers.AnyAsync()) return;

            var nakesUserData = await File.ReadAllTextAsync("../Bintangku.Data/NakesUserSeedData.json");
            var users = JsonSerializer.Deserialize<List<NakesUser>>(nakesUserData);
            
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$word"));
                user.PasswordSalt = hmac.Key;

                context.NakesUsers.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}