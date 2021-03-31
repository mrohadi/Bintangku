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
    public class PemeriksaanMchatController : BaseApiController
    {
        private IPemeriksaanMchatRepository _repository;
        public PemeriksaanMchatController(IPemeriksaanMchatRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// GET data pemeriksaan M-CHAT based on specific dataAnakId
        /// </summary>
        /// <param name="dataAnakId">Uniques dataAnakId</param>
        /// <returns>Data pemeriksaan M-CHAT</returns>
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<IEnumerable<PemeriksaanMchat>>> GetPemeriksaanMchat(int dataAnakId)
        {
            try
            {
               var dataPemeriksaanMchat = await _repository.GetPemeriksaanMchat(dataAnakId);
                    
                if(dataPemeriksaanMchat == null)
                    return BadRequest();
                return Ok(dataPemeriksaanMchat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            } 
        }

        /// <summary>
        /// POST data pemeriksaan M-CHAT to data base based on specific dataAnakId
        /// </summary>
        /// <param name="dataAnakId">Uniques dataAnakId</param>
        /// <param name="pemeriksaanMchatDto">Data transfer object for pemeriksaan M-CHAT</param>
        /// <returns></returns>
        [HttpPost("{dataAnakId}")]
        public async Task<IActionResult> PostPemeriksaanMchat(
            int dataAnakId, [FromBody]PemeriksaanMchatDto pemeriksaanMchatDto)
        {
            try
            {
                await _repository.PostPemeriksaanMchat(dataAnakId, pemeriksaanMchatDto);
                
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