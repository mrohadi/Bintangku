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
    public class PemeriksaanStatusGiziImtUController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public PemeriksaanStatusGiziImtUController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                var statusGiziImtU = await _unitOfWork.PemeriksaanStatusGiziImtURepository
                    .GetStatusGiziImtUAsync(dataAnakId);

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
                await _unitOfWork.PemeriksaanStatusGiziImtURepository
                    .PostStatusGiziImtUAsync(dataAnakId, dto);

                if(await _unitOfWork.Complete()) 
                    return Ok();
                return BadRequest("Failed to save status gizi IMT/U!");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}