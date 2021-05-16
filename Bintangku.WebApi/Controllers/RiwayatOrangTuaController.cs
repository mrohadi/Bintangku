using System;
using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class RiwayatOrangTuaController : BaseApiController
    {
        private readonly IRiwayatOrangTuaRepository _repository;
        private readonly ApplicationDataContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public RiwayatOrangTuaController(IUnitOfWork unitOfWork,IRiwayatOrangTuaRepository repository, ApplicationDataContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _repository = repository;
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