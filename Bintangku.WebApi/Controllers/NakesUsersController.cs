using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bintangku.WebApi.Extensions;
using Bintangku.WebApi.Interfaces;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Data.DTO;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class NakesUsersController : BaseApiController
    {
        private readonly INakesUserRepository _nakesUserRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        public NakesUsersController(
        INakesUserRepository nakesUserRepository, IMapper mapper, IPhotoService photoService)
        {
            _photoService = photoService;
            _mapper = mapper;
            _nakesUserRepository = nakesUserRepository;
        }

        /// <summary>
        /// HTTP Get method to get nakes user data from database
        /// </summary>
        /// <returns>List of nakes users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberNakesUserDto>>> GetNakesUsers()
        {
            var users = await _nakesUserRepository.GetMembersAsync();

            return Ok(users);
        }

        /// <summary>
        /// HTTP Post method to get specific nakes user (api/nakesusers/1)
        /// </summary>
        /// <param name="id">id of specific nakes user</param>
        /// <returns>nakes user based on given id</returns>
        [HttpGet("{nakesUsername}", Name = "GetUser")]
        public async Task<ActionResult<MemberNakesUserDto>> GetNakesUser(string nakesUsername)
        {
            return await _nakesUserRepository.GetMemberAsync(nakesUsername);
        }

        /// <summary>
        /// HTTP Update method to update nakes profile
        /// </summary>
        /// <param name="memberNakesUserUpdateDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateNakesUser(
            MemberNakesUserUpdateDto memberNakesUserUpdateDto)
        {
            var username = User.GetUserName();
            var user = await _nakesUserRepository.GetNakesUserByUsername(username);

            _mapper.Map(memberNakesUserUpdateDto, user);

            _nakesUserRepository.Update(user);

            if (await _nakesUserRepository.SaveAllAsync()) 
                return NoContent();
            return BadRequest();
        }

        /// <summary>
        /// Upload New Nakes User Photo and Save it to Cloudnary
        /// </summary>
        /// <param name="file">Photo to Upload</param>
        /// <returns></returns>
        [HttpPost("add-photo")]
        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
        {
            var username = User.GetUserName();
            var user = await _nakesUserRepository.GetNakesUserByUsername(username);

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null) 
                return BadRequest(result.Error.Message);
            
            var photo = new Photo
            {
                Url = result.Url.AbsoluteUri,
                PublicId = result.PublicId  
            };

            if (user.Photos.Count == 0)
            {
                photo.IsMain = true;
            }

            user.Photos.Add(photo);
            
            if (await _nakesUserRepository.SaveAllAsync())
            {
                // return _mapper.Map<PhotoDto>(photo);
                return CreatedAtRoute(
                    "GetUser", new { nakesUsername = user.UserName}, _mapper.Map<PhotoDto>(photo));
            }

            return BadRequest("Problem adding photo");
        }

        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int photoId)
        {
            var user = await _nakesUserRepository.GetNakesUserByUsername(User.GetUserName());

            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo.IsMain)
            {
                return BadRequest("This is already your main photo");
            }

            var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);
            if (currentMain != null)
            {
                currentMain.IsMain = false;
            }
            photo.IsMain = true;

            if (await _nakesUserRepository.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("Failed to set main photo");
        }

        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            var user = await _nakesUserRepository.GetNakesUserByUsername(User.GetUserName());

            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo == null)
                return NotFound();

            if (photo.IsMain)
                return BadRequest("You cannot delete your main photo");

            if (photo.PublicId != null)
            {
                var result = await _photoService.DeletePhotoAsync(photo.PublicId);
                if (result.Error != null)
                    return BadRequest(result.Error.Message);
            }

            user.Photos.Remove(photo);

            if (await _nakesUserRepository.SaveAllAsync())
                return Ok();
            
            return BadRequest("Failed to delete the photo!");
        }
    }
}