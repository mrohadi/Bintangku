using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bintangku.WebApi.Interfaces;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class UploadController : BaseApiController
    {
        private readonly IPhotoService _photoService;
        public UploadController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        /// <summary>
        /// Upload Photo Anak To Cloudinary
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("photo-anak")]
        public async Task<ActionResult> UploadPhotoAnak(IFormFile file)
        {
            var result = await _photoService.AddPhotoAsync(file);

            if(result.Error != null)
                return BadRequest();

            return Ok(new { Url = result.SecureUrl });
        }
        
        [HttpPost("ttd")]
        public async Task<ActionResult> UploadTtd(IFormFile file)
        {
            var result = await _photoService.AddPhotoAsync(file);

            if(result.Error != null)
                return BadRequest();
            
            return Ok(new { Url = result.SecureUrl });
        }
    }
}