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
    public class PemeriksaanStatusGiziBbTbController : BaseApiController
    {
        private IPemeriksaanStatusGiziBbTbRepository _repository;
        public PemeriksaanStatusGiziBbTbController(IPemeriksaanStatusGiziBbTbRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<IEnumerable<PemeriksaanStatusGiziBbTb>>> GetGiziBbTb(
            int dataAnakId)
        {
            try
            {
                var statusGiziBbTb = await _repository.GetStatusGizi(dataAnakId);

                if(statusGiziBbTb == null)
                    return BadRequest("Status gizi berat badan / tinggi badan tidak ditemukan");
                return Ok(statusGiziBbTb);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("{dataAnakId}")]
        public async Task<IActionResult> PostStatusGiziBbTb(
            int dataAnakId, PemeriksaanStatusGiziBbTbDto dto)
        {
            try
            {
                await _repository.PostPemeriksaanStatusGiziBbTb(dataAnakId, dto);

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