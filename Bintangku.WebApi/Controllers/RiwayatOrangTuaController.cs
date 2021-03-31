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
        private IRiwayatOrangTuaRepository _repository;
        private ApplicationDataContext _context;
        public RiwayatOrangTuaController(IRiwayatOrangTuaRepository repository, ApplicationDataContext context)
        {
            _context = context;
            _repository = repository;
        }
        
        [HttpGet("{dataAnakId}")]
        public async Task<ActionResult<RiwayatOrangTua>> GetRiwayatOrangTua(int dataAnakId)
        {
            try
            {
                var riwayatOrangTua = await _repository.GetRiwayatOrangTuaAsync(dataAnakId);

                if (riwayatOrangTua == null)
                    return BadRequest("Riwayat Orang Tua Tidak Ditemukan");
                return Ok(riwayatOrangTua);
            }
            catch (System.Exception)
            {
                throw;
            }    
        }
    }
}