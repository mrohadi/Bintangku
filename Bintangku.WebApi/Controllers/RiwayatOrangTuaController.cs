using System;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class RiwayatOrangTuaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public RiwayatOrangTuaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<RiwayatOrangTua>> GetRiwayatOrangTua(int dataAnakId)
        {
            try
            {
                var riwayatOrangTua = await _unitOfWork.RiwayatOrangTuaRepository
                    .GetRiwayatOrangTuaAsync(dataAnakId); 

                if (riwayatOrangTua == null)
                    return BadRequest("Riwayat Orang Tua Tidak Ditemukan");
                return Ok(riwayatOrangTua);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Riwayat Orang Tua Tidak Ditemukan! {ex}");
            }    
        }

        [HttpPut("{dataAnakId}")]
        public async Task<IActionResult> UpdateRiwayatOrangTua(
            int dataAnakId, [FromBody] RiwayatOrangTua riwayatOrangTua)
        {
            try
            {
                await _unitOfWork.RiwayatOrangTuaRepository
                    .UpdateRiwayatOrangTuaAsync(dataAnakId, riwayatOrangTua);
                
                if(await _unitOfWork.Complete())
                    return Ok();
                return BadRequest("Gagal Update Riwayat Orang Tua!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}