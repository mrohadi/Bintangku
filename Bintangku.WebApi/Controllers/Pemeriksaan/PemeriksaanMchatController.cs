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
    public class PemeriksaanMchatController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public PemeriksaanMchatController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                var dataPemeriksaanMchat = await _unitOfWork.PemeriksaanMchatRepository
                    .GetPemeriksaanMchat(dataAnakId);
                    
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
                await _unitOfWork.PemeriksaanMchatRepository
                    .PostPemeriksaanMchat(dataAnakId, pemeriksaanMchatDto);
                
                if(await _unitOfWork.Complete())
                    return Ok();
                return BadRequest("Failed to save data hasil pemeriksaan MCHAT");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }
        }
    }
}