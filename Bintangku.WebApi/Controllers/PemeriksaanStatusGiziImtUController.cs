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
    public class PemeriksaanStatusGiziImtUController : BaseApiController
    {
        private IPemeriksaanStatusGiziImtURepository _repository;
        public PemeriksaanStatusGiziImtUController(IPemeriksaanStatusGiziImtURepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataAnakId"></param>
        /// <returns></returns>
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<IEnumerable<PemeriksaanStatusGiziImtU>>> GetStatusGiziImtU(
            int dataAnakId)
        {
            try
            {
                var statusGiziImtU = await _repository.GetStatusGiziImtUAsync(dataAnakId);

                if(statusGiziImtU == null)
                    return BadRequest("Status gizi IMT/U tidak ditemukan!");
                return Ok(statusGiziImtU);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("{dataAnakId}")]
        public async Task<IActionResult> PostGiziImtU(
            int dataAnakId, PemeriksaanStatusGiziImtUDto dto)
        {
            try
            {
                await _repository.PostStatusGiziImtUAsync(dataAnakId, dto);

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