using System;
using System.Threading.Tasks;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class RiwayatKelahiranController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public RiwayatKelahiranController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// Get data riwayat kelahiran anak
        /// </summary>
        /// <param name="dataAnakId">Unique dataAnakId</param>
        /// <returns>Data riwayat kelahiran anak</returns>
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<RiwayatKelahiran>> GetRiwayatKelahiran(int dataAnakId)
        {
            try
            {
                RiwayatKelahiran kelahiran = await _unitOfWork.RiwayatKelahiranRepository
                    .GetRiwayatKelahiran(dataAnakId);

                if(kelahiran == null)
                    return BadRequest("Riwayat Kelahiran Anak Tidak Ditemukan!");
                return Ok(kelahiran);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Riwayat Kelahiran Tidak Ditemukan! {ex}");
            }
        }

        [HttpPut("{dataAnakId}")]
        public async Task<IActionResult> UpdateRiwayatKelahiran(
            int dataAnakId, RiwayatKelahiran riwayatKelahiran)
        {
            try
            {
                await _unitOfWork.RiwayatKelahiranRepository
                    .UpdateRiwayatKelahiran(dataAnakId, riwayatKelahiran);
                
                if(await _unitOfWork.Complete())
                    return Ok();
                return BadRequest();    
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Gagal Mengupdate Riwayat Kelahiran! {ex}");
            }
        }
    }
}