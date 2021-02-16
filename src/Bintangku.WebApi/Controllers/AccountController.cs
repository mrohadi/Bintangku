using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Bintangku.Data;
using Bintangku.Data.DTO;
using Bintangku.Data.Entities;
using Bintangku.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ApplicationDataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(ApplicationDataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        /// <summary>
        /// Register a nakes user
        /// </summary>
        /// <param name="registerDto">nakes user object</param>
        /// <returns>nakes user object (Nakes User DTO)</returns>
        [HttpPost("register")]
        public async Task<ActionResult<NakesUserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username already exist");

            using var hmac = new HMACSHA512();

            var nakesUser = new NakesUser
            {
                UserName = registerDto.Username.ToLower(),
                FullName = registerDto.FullName,
                PhoneNumber = registerDto.PhoneNumber,
                NoStrTenagaKesehatan = registerDto.NoStrTenagaKesehatan,
                TempatPelayanan = registerDto.TempatPelayanan,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.NakesUsers.Add(nakesUser);
            await _context.SaveChangesAsync();

            return new NakesUserDto
            {
                Username = nakesUser.UserName,
                Token = _tokenService.CreateToken(nakesUser)
            };
        }

        /// <summary>
        /// Login the nakes user
        /// </summary>
        /// <param name="loginDto">nakes user login object</param>
        /// <returns>logined nakes user</returns>
        [HttpPost("login")]
        public async Task<ActionResult<NakesUserDto>> Login(LoginDto loginDto) 
        {
            var nakesUser = await _context.NakesUsers 
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
            
            if (nakesUser == null) return Unauthorized("Invalid Username");

            using var hmac = new HMACSHA512(nakesUser.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != nakesUser.PasswordHash[i])
                    return Unauthorized("Invalid Password");
            }

            return new NakesUserDto
            {
                Username = nakesUser.UserName,
                Token = _tokenService.CreateToken(nakesUser)
            };
        }

        /// <summary>
        /// Helper method - Check if nakes users already exist in the database
        /// </summary>
        /// <param name="username">nakes username to be registered</param>
        /// <returns>true or false</returns>
        private async Task<bool> UserExists(string username)
        {
            return await _context.NakesUsers.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}