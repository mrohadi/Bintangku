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
    public class NutritionalStatusBbTbCheckupController : BaseApiController
    {
        private INutritionalStatusBbTbCheckupRepository _repository;
        public NutritionalStatusBbTbCheckupController(INutritionalStatusBbTbCheckupRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <returns></returns>
        [HttpGet("nutritional-status-bb-tb-checkup/{childDataId}")]
        public async Task<ActionResult<IEnumerable<NutritionalStatusBbTbCheckup>>> GetNutritionalStatusBbTbCheckupAsync(
            int childDataId)
        {
            try
            {
                var result = await _repository.GetNutritionalStatusBbTbCheckupsAsync(childDataId);

                if(result == null)
                    return BadRequest("Status gizi berat badan / tinggi badan tidak ditemukan");
                return Ok(result);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("nutritional-status-bb-tb-checkup/{childDataId}")]
        public async Task<IActionResult> PostNutritionalStatusBbTbCheckupAsync(
            int childDataId, PemeriksaanStatusGiziBbTbDto dto)
        {
            try
            {
                await _repository.PostNutritionalStatusBbTbCheckupAsync(childDataId, dto);

                if(await _repository.SaveAllAsync())
                    return NoContent();
                return BadRequest("Failed to save status gizi berat badan / tinggi badan");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}