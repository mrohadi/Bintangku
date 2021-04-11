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
    public class HeadCircumferenceCheckupController : BaseApiController
    {
        private IHeadCircumferenceCheckupRepository _repository;
        public HeadCircumferenceCheckupController(IHeadCircumferenceCheckupRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <returns></returns>
        [HttpGet("head-circumference-checkup/{childDataId}")]    
        public async Task<ActionResult<IEnumerable<HeadCircumferenceCheckup>>> GetHeadCircumferenceCheckupAsync(
            int childDataId)
        {
            try
            {
                var headCircum = await _repository.GetHeadCircumferenceCheckupAsync(childDataId);

                if(headCircum == null)
                    return BadRequest("Pemeriksaan lingkar kepala tidak ditemukan!");
                return Ok(headCircum);
            }
            catch (System.Exception)
            {
                throw;
            }    
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("head-circumference-checkup/{childDataId}")]
        public async Task<IActionResult> PostHeadCircumferenceCheckupAsync(
            int childDataId, PemeriksaanLingkarKepalaDto dto)
        {
            try
            {
                await _repository.PostHeadCircumferenceCheckupAsync(childDataId, dto);
                
                if(await _repository.SaveAllAsync())
                    return NoContent();
                return BadRequest("Failed to save pemeriksaan lingkar kepala!");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}