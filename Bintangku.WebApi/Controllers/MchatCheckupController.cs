using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Interfaces;
using System.Collections.Generic;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class MchatCheckupController : BaseApiController
    {
        private IMchatCheckupRepository _repository;
        public MchatCheckupController(IMchatCheckupRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// GET data pemeriksaan M-CHAT based on specific dataAnakId
        /// </summary>
        /// <param name="childDataId">Uniques dataAnakId</param>
        /// <returns>Data pemeriksaan M-CHAT</returns>
        [HttpGet("mchat-checkup/{childDataId}")]
        public async Task<ActionResult<IEnumerable<MchatCheckup>>> GetMchatCheckupAsync(int childDataId)
        {
            try
            {
               var mchat = await _repository.GetMchatCheckupAsync(childDataId);
                    
                if(mchat == null)
                    return BadRequest();
                return Ok(mchat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            } 
        }

        /// <summary>
        /// POST data pemeriksaan M-CHAT to data base based on specific dataAnakId
        /// </summary>
        /// <param name="childDataId">Uniques childDataId</param>
        /// <param name="pemeriksaanMchatDto">Data transfer object for pemeriksaan M-CHAT</param>
        /// <returns></returns>
        [HttpPost("mchat-checkup/{childDataId}")]
        public async Task<IActionResult> PostMchatCheckupAsync(
            int childDataId, [FromBody]PemeriksaanMchatDto pemeriksaanMchatDto)
        {
            try
            {
                await _repository.PostMchatCheckupAsync(childDataId, pemeriksaanMchatDto);
                
                if(await _repository.SaveAllAsync())
                    return NoContent();
                return BadRequest("Failed to save data hasil pemeriksaan MCHAT");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
    }
}