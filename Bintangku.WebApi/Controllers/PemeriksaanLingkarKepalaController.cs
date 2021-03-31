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
    public class PemeriksaanLingkarKepalaController : BaseApiController
    {
        private IPemeriksaanLingkarKepalaRepository _repository;
        public PemeriksaanLingkarKepalaController(IPemeriksaanLingkarKepalaRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        [HttpGet("{dataAnakId}")]    
        public async Task<ActionResult<IEnumerable<PemeriksaanLingkarKepala>>> GetLingkarKepala(
            int dataAnakId)
        {
            try
            {
                var lingkarKepala = await _repository.GetLingkarKepalaAsync(dataAnakId);

                if(lingkarKepala == null)
                    return BadRequest("Pemeriksaan lingkar kepala tidak ditemukan!");
                return Ok(lingkarKepala);
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
        public async Task<IActionResult> PostLingkarKepala(
            int dataAnakId, PemeriksaanLingkarKepalaDto dto)
        {
            try
            {
                await _repository.PostLingkatKepalaAsync(dataAnakId, dto);
                
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