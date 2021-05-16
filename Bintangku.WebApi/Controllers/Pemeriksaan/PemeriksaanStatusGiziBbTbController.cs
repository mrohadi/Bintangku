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
    public class PemeriksaanStatusGiziBbTbController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public PemeriksaanStatusGiziBbTbController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                var statusGiziBbTb = await _unitOfWork.PemeriksaanStatusGiziBbTbRepository
                    .GetStatusGizi(dataAnakId);

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
                await _unitOfWork.PemeriksaanStatusGiziBbTbRepository
                    .PostPemeriksaanStatusGiziBbTb(dataAnakId, dto);

                if(await _unitOfWork.Complete())
                    return Ok();
                return BadRequest("Failed to save status gizi berat badan / tinggi badan");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}