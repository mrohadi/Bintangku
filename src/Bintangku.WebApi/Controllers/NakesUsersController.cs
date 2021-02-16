using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Bintangku.Data.DTO;
using Bintangku.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class NakesUsersController : BaseApiController
    {
        private readonly INakesUserRepository _nakesUserRepository;
        private readonly IMapper _mapper;
        public NakesUsersController(INakesUserRepository nakesUserRepository, IMapper mapper)
        {
            _mapper = mapper;
            _nakesUserRepository = nakesUserRepository;
        }

        /// <summary>
        /// Http get method to get nakes user data from database
        /// </summary>
        /// <returns>List of nakes users</returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberNakesUserDto>>> GetNakesUsers()
        {
            var users = await _nakesUserRepository.GetMembersAsync();

            return Ok(users);
        }

        /// <summary>
        /// api/nakesusers/1
        /// </summary>
        /// <param name="id">id of specific nakes user</param>
        /// <returns>nakes user based on given id</returns>

        [HttpGet("{nakesUsername}")]
        public async Task<ActionResult<MemberNakesUserDto>> GetNakesUser(string nakesUsername)
        {
            return await _nakesUserRepository.GetMemberAsync(nakesUsername);
        }

        /// <summary>
        /// Update Nakes profile
        /// </summary>
        /// <param name="memberNakesUserUpdateDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateNakesUser(
            MemberNakesUserUpdateDto memberNakesUserUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _nakesUserRepository.GetNakesUserByUsername(username);

            _mapper.Map(memberNakesUserUpdateDto, user);

            _nakesUserRepository.Update(user);

            if (await _nakesUserRepository.SaveAllAsync()) return NoContent();
            return BadRequest();
        }
    }
}