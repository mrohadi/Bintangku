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
using System.Collections.Generic;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class PemeriksaanGpphController : BaseApiController
    {
        private IPemeriksaanGpphRepository _repository;
        public PemeriksaanGpphController(IPemeriksaanGpphRepository repository, ApplicationDataContext context)
        {
            _repository = repository;
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
                var pemeriksaanGpph = await _repository.GetPemeriksaanGpph(dataAnakId);
                
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
                await _repository.PostPemeriksaanGpph(dataAnakId, pemeriksaanGpphDto);
                
                if (await _repository.SaveAllAsync())
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