using System;
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
    public class PemeriksaanKmpeController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public PemeriksaanKmpeController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// GET specific data pemeriksaaan KMPE based on dataAnakId 
        /// </summary>
        /// <param name="dataAnakId">Uniques dataAnakId</param>
        /// <returns>Data pemriksaan KMPE</returns>
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<IEnumerable<PemeriksaanKmpe>>> GetPemeriksaanKmpe(int dataAnakId)
        {
            try
            {
                var dataPemeriksaanKmpe = await _unitOfWork.PemeriksaanKmpeRepository
                    .GetPemeriksaanKmpe(dataAnakId);

                if(dataPemeriksaanKmpe == null) 
                    return BadRequest();
                return Ok(dataPemeriksaanKmpe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        /// <summary>
        /// POST data kesehatan KMPE to data base based on dataAnakId
        /// </summary>
        /// <param name="dataAnakId">Uniques dataAnakId</param>
        /// <param name="pemeriksaanKmpeDto">Data transfer object for pemeriksaan KMPE</param>
        /// <returns>No return</returns>
        [HttpPost("{dataAnakId}")]
        public async Task<IActionResult> PostPemeriksaanKmpe(
            int dataAnakId, [FromBody]PemeriksaanKmpeDto pemeriksaanKmpeDto)
        {
            try
            {
                await _unitOfWork.PemeriksaanKmpeRepository
                    .PostPemeriksaanKmpe(dataAnakId, pemeriksaanKmpeDto); 
                
                if(await _unitOfWork.Complete()) 
                    return Ok();
                return BadRequest("Failed to add save pemeriksaan KMPE to data base");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
    }
}