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
    public class KmpeCheckupController : BaseApiController
    {
        private IKmpeCheckupRepository _repository;
        public KmpeCheckupController(IKmpeCheckupRepository repository) 
        {
            _repository = repository;
        }

        /// <summary>
        /// GET specific data pemeriksaaan KMPE based on dataAnakId 
        /// </summary>
        /// <param name="childDataId">Uniques childDataId</param>
        /// <returns>Data pemriksaan KMPE</returns>
        [HttpGet("kmpe-checkup/{childDataId}")]
        public async Task<ActionResult<IEnumerable<KmpeCheckup>>> GetKmpeCheckupAsync(int childDataId)
        {
            try
            {
                var kmpe = await _repository.GetKmpeCheckupsAsync(childDataId);

                if(kmpe == null) 
                    return BadRequest();
                return Ok(kmpe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }

        /// <summary>
        /// POST data kesehatan KMPE to data base based on dataAnakId
        /// </summary>
        /// <param name="childDataId">Uniques childDataId</param>
        /// <param name="pemeriksaanKmpeDto">Data transfer object for pemeriksaan KMPE</param>
        /// <returns>No return</returns>
        [HttpPost("kmpe-checkup/{childDataId}")]
        public async Task<IActionResult> PostKmpeCheckupAsync(
            int childDataId, [FromBody]PemeriksaanKmpeDto pemeriksaanKmpeDto)
        {
            try
            {
                await _repository.PostKmpeCheckupAsync(childDataId, pemeriksaanKmpeDto); 
                
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