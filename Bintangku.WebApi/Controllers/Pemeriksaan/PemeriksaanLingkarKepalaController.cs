using System.Collections.Generic;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.DTO.Pemeriksaan;
using Bintangku.WebApi.Data.Entities.Pemeriksaan;
using Bintangku.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bintangku.WebApi.Controllers.Pemeriksaan
{
    [Authorize]
    public class PemeriksaanLingkarKepalaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public PemeriksaanLingkarKepalaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                var lingkarKepala = await _unitOfWork.PemeriksaanLingkarKepalaRepository
                    .GetLingkarKepalaAsync(dataAnakId);

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
                await _unitOfWork.PemeriksaanLingkarKepalaRepository
                    .PostLingkatKepalaAsync(dataAnakId, dto);
                
                if(await _unitOfWork.Complete())
                    return Ok();
                return BadRequest("Failed to save pemeriksaan lingkar kepala!");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}