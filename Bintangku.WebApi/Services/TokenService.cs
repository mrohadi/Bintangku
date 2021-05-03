using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Bintangku.WebApi.Interfaces;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<NakesUser> _userManager;
        public TokenService(IConfiguration config, UserManager<NakesUser> userManager)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _userManager = userManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nakesUser"></param>
        /// <returns></returns>
        public async Task<string> CreateToken(NakesUser nakesUser)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, nakesUser.Id.ToString()),
                new  Claim(JwtRegisteredClaimNames.UniqueName, nakesUser.UserName),
            };
            
            var roles = await _userManager.GetRolesAsync(nakesUser);
            
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                // FIXME: change the days
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}