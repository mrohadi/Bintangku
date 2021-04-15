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
    public class GpphCheckupController : BaseApiController
    {
        private IGpphCheckupRepository _repository;
        public GpphCheckupController(IGpphCheckupRepository repository, ApplicationDataContext context)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// GET data pemeriksaan GPPH
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <returns>Data pemeriksaan GPPH</returns>
        [HttpGet("gpph-checkup/{childDataId}")]
        public async Task<ActionResult<IEnumerable<GpphCheckup>>> GetGpphCheckupAsync(int childDataId)
        {
            try
            {
                var result = await _repository.GetGpphCheckupsAsync(childDataId);
                
                if (result == null)
                    return BadRequest();
                return Ok(result); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        /// <summary>
        /// POST data pemeriksaan Gpph to specific data kesehatan anak
        /// </summary>
        /// <param name="childDataId">Unique dataAnakId</param>
        /// <param name="pemeriksaanGpphDto">Data transfer object for pemeriksaan GPPH</param>
        /// <returns></returns>
        [HttpPost("gpph-checkup/{childDataId}")] 
        public async Task<IActionResult> PostGpphCheckupAsync(
            int childDataId, [FromBody]PemeriksaanGpphDto pemeriksaanGpphDto)
        {
            try
            {
                await _repository.PostGpphCheckupAsync(childDataId, pemeriksaanGpphDto);
                
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