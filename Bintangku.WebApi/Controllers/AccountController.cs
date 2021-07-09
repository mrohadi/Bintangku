using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Interfaces;
using Bintangku.WebApi.Data.DTO;
using System.Linq;

namespace Bintangku.WebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<NakesUser> _userManager;
        private readonly SignInManager<NakesUser> _signInManager;
        public AccountController(
            ITokenService tokenService, 
            UserManager<NakesUser> userManager, 
            SignInManager<NakesUser> signInManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Register a nakes user
        /// </summary>
        /// <param name="registerDto">nakes user object</param>
        /// <returns>nakes user object (Nakes User DTO)</returns>
        [HttpPost("register")]
        public async Task<ActionResult<NakesUserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) 
                return BadRequest("Username already exist");
            
            if(registerDto == null)
                return BadRequest();

            var nakesUser = new NakesUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Username.ToLower(),
                FullName = registerDto.FullName,
                PhoneNumber = registerDto.PhoneNumber,
                NoStrTenagaKesehatan = registerDto.NoStrTenagaKesehatan,
                TempatPelayanan = registerDto.TempatPelayanan,
            };
            
            var result = await _userManager.CreateAsync(nakesUser, registerDto.Password);
            
            if (!result.Succeeded) 
                return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(nakesUser, "Nakes");

            if (!roleResult.Succeeded) 
                return BadRequest(roleResult.Errors);

            return new NakesUserDto
            {
                Username = nakesUser.UserName,
                Token = await _tokenService.CreateToken(nakesUser)
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
            var nakesUser = new NakesUser();
            if (!string.IsNullOrEmpty(loginDto.Email))
                nakesUser = await _userManager.Users
                    .Where(email => email.Email == loginDto.Email)
                    .SingleOrDefaultAsync();
            
            if (!string.IsNullOrEmpty(loginDto.Username))
                nakesUser = await _userManager.Users
                    .Where(un => un.UserName == loginDto.Username)
                    .SingleOrDefaultAsync();
            
            if (nakesUser == null) return BadRequest("Invalid Username Or Email");
            
            var result = await _signInManager
                .CheckPasswordSignInAsync(nakesUser, loginDto.Password,  false);
            
            if (!result.Succeeded) return Unauthorized("Invalid Password");

            return new NakesUserDto
            {
                Username = nakesUser.UserName,
                Token = await _tokenService.CreateToken(nakesUser)
            };
        }

        /// <summary>
        /// Helper method - Check if nakes users already exist in the database
        /// </summary>
        /// <param name="username">nakes username to be registered</param>
        /// <returns>true or false</returns>
        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}