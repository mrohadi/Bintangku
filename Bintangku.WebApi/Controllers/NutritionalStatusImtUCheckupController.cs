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
    public class NutritionalStatusImtUCheckupController : BaseApiController
    {
        private INutritionalStatusImtUCheckupRepository _repository;
        public NutritionalStatusImtUCheckupController(INutritionalStatusImtUCheckupRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <returns></returns>
        [HttpGet("nutritional-status-imt-u-checkup/{childDataId}")]
        public async Task<ActionResult<IEnumerable<NutritionalStatusImtUCheckup>>> GetNutritionalStatusImtUCheckupAsync(
            int childDataId)
        {
            try
            {
                var nutritionalImtU = await _repository.GetNutritionalStatusImtUCheckupsAsync(childDataId);

                if(nutritionalImtU == null)
                    return BadRequest("Status gizi IMT/U tidak ditemukan!");
                return Ok(nutritionalImtU);
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
        [HttpPost("nutritional-status-imt-u-checkup/{childDataId}")]
        public async Task<IActionResult> PostNutritionalStatusImtUCheckupAsync(
            int childDataId, PemeriksaanStatusGiziImtUDto dto)
        {
            try
            {
                await _repository.PostNutritionalStatusImtUCheckupAsync(childDataId, dto);

                if(await _repository.SaveAllAsync()) 
                    return NoContent();
                return BadRequest("Failed to save status gizi IMT/U!");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}