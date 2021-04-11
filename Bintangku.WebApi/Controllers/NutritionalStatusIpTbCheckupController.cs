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
    public class NutritionalStatusIpTbCheckupController : BaseApiController
    {
        private INutritionalStatusIpTbCheckupRepository _repository;
        public NutritionalStatusIpTbCheckupController(INutritionalStatusIpTbCheckupRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childDataId"></param>
        /// <returns></returns>
        [HttpGet("nutritional-status-ip-tb-checkup/{childDataId}")]
        public async Task<ActionResult<IEnumerable<NutritionalStatusIpTbCheckupController>>> GetNutritionalStatusIpTbCheckupAsync(
            int childDataId)
        {
            try
            {
                var nutritionalStatusIpTb = await _repository.GetNutritionalStatusIpTbCheckupsAsync(childDataId); 

                if(nutritionalStatusIpTb == null)
                    return BadRequest("Pemeriksaan status gizi IP/TB tidak ditemukan!");
                return Ok(nutritionalStatusIpTb);
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
        [HttpPost("nutritional-status-ip-tb-checkup/{childDataId}")]
        public async Task<IActionResult> PostNutritionalStatusIpTbCheckupAsync(
            int childDataId, PemeriksaanStatusGiziIpTbDto dto)
        {
            try
            {
                await _repository.PostNutritionalStatusIpTbChekcupAsync(childDataId, dto);

                if(await _repository.SaveAllAsync()) 
                    return NoContent();
                return BadRequest("Failed to save status gizi IP/Tb!");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}