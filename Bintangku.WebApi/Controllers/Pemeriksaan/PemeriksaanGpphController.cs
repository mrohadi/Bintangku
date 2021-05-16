using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bintangku.WebApi.Interfaces;
using System.Collections.Generic;
using Bintangku.WebApi.Data.Entities.Pemeriksaan;
using Bintangku.WebApi.Data.DTO.Pemeriksaan;

namespace Bintangku.WebApi.Controllers.Pemeriksaan
{
    [Authorize]
    public class PemeriksaanGpphController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public PemeriksaanGpphController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// GET data pemeriksaan GPPH
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>Data pemeriksaan GPPH</returns>
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<IEnumerable<PemeriksaanGpph>>> GetPemeriksaanGpph(int dataAnakId)
        {
            try
            {
                var pemeriksaanGpph = await _unitOfWork.PemeriksaanGpphRepository
                    .GetPemeriksaanGpph(dataAnakId);
                
                if (pemeriksaanGpph == null)
                    return BadRequest();
                return Ok(pemeriksaanGpph); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        /// <summary>
        /// POST data pemeriksaan Gpph to specific data kesehatan anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <param name="pemeriksaanGpphDto">Data transfer object for pemeriksaan GPPH</param>
        /// <returns></returns>
        [HttpPost("{dataAnakId}")] 
        public async Task<IActionResult> CreatePemeriksaanGpph(int dataAnakId, [FromBody]PemeriksaanGpphDto pemeriksaanGpphDto)
        {
            try
            {
                await _unitOfWork.PemeriksaanGpphRepository
                    .PostPemeriksaanGpph(dataAnakId, pemeriksaanGpphDto);
                
                if (await _unitOfWork.Complete())
                    return Ok();
                return BadRequest("Failed to add Pemeriksaan GPPH");            
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
    }
}