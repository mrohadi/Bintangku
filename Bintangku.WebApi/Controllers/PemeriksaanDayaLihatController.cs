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
    public class PemeriksaanDayaLihatController : BaseApiController
    {
        private IPemeriksaanDayaLihatRepository _repository;
        public PemeriksaanDayaLihatController(IPemeriksaanDayaLihatRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// Get list tes daya lihat anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>List tes daya lihat anak</returns>
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<IEnumerable<PemeriksaanDayaLihat>>> GetTesDayaLihat(int dataAnakId)
        {
            try
            {
                var tesDayaLihat = await _repository.GetTesDayaLihat(dataAnakId);

                if(tesDayaLihat == null)
                    return BadRequest("Tes Daya Lihat Tidak Ditemukan");
                return Ok(tesDayaLihat);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Post tes daya lihat anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <param name="tesDayaLihatDto">Model tes daya lihat to post</param>
        /// <returns>No return</returns>
        [HttpPost("{dataAnakId}")]
        public async Task<IActionResult> PostTesDayaLihat(
            int dataAnakId, PemeriksaanDayaLihatDto dto)
        {
            try
            {
                await _repository.PostDayaLihat(dataAnakId, dto);

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