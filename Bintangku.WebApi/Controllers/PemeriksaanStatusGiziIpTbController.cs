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
    public class PemeriksaanStatusGiziIpTbController : BaseApiController
    {
        private IPemeriksaanStatusGiziIpTbRepository _repository;
        public PemeriksaanStatusGiziIpTbController(IPemeriksaanStatusGiziIpTbRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<IEnumerable<PemeriksaanStatusGiziIpTb>>> GetStatusGiziIpTb(
            int dataAnakId)
        {
            try
            {
                var statusGiziIpTb = await _repository.GetStatusGiziIpTbAsync(dataAnakId); 

                if(statusGiziIpTb == null)
                    return BadRequest("Pemeriksaan status gizi IP/TB tidak ditemukan!");
                return Ok(statusGiziIpTb);
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
        [HttpPost("{dataAnakId}")]
        public async Task<IActionResult> PostStatusGiziIpTb(
            int dataAnakId, PemeriksaanStatusGiziIpTbDto dto)
        {
            try
            {
                await _repository.PostStatusGiziIpTbAsync(dataAnakId, dto);

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