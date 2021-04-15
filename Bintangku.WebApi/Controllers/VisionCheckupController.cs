using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class VisionCheckupController : BaseApiController
    {
        private IVisionCheckupRepository _repository;
        public VisionCheckupController(IVisionCheckupRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// Get list vision checkup 
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <returns>List tes daya lihat anak</returns>
        [HttpGet("vision-checkup/{childDataId}")]
        public async Task<ActionResult<IEnumerable<VisionCheckup>>> GetVisionCheckupAsyc(int childDataId)
        {
            try
            {
                var result = await _repository.GetVisionCheckupsAsync(childDataId);

                if(result == null)
                    return BadRequest("Vision Checkup Not Found!");
                return Ok(result);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Post visio checkup
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <param name="tesDayaLihatDto">Model tes daya lihat to post</param>
        /// <returns>No return</returns>
        [HttpPost("vision-checkup/{childDataId}")]
        public async Task<IActionResult> PostVisionCheckup(
            int childDataId, PemeriksaanDayaLihatDto dto)
        {
            try
            {
                await _repository.PostVisionCheckupAsync(childDataId, dto);

                if(await _repository.SaveAllAsync()) 
                    return Ok();
                return BadRequest("Failed to save hasil tes daya lihat anak");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}