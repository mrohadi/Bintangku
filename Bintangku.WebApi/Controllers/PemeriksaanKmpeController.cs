using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Interfaces;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class PemeriksaanKmpeController : BaseApiController
    {
        private IPemeriksaanKmpeRepository _repository;
        public PemeriksaanKmpeController(IPemeriksaanKmpeRepository repository) 
        {
            _repository = repository;
        }

        /// <summary>
        /// GET specific data pemeriksaaan KMPE based on dataAnakId 
        /// </summary>
        /// <param name="dataAnakId">Uniques dataAnakId</param>
        /// <returns>Data pemriksaan KMPE</returns>
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<PemeriksaanKmpe>> GetPemeriksaanKmpe(int dataAnakId)
        {
            try
            {
                var dataPemeriksaanKmpe = await _repository.GetPemeriksaanKmpe(dataAnakId);

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
                await _repository.PostPemeriksaanKmpe(dataAnakId, pemeriksaanKmpeDto); 
                
                if(await _repository.SaveAllAsync()) 
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