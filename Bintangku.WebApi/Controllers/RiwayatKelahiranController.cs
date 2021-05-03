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
        private IRiwayatKelahiranRepository _repository;
        public RiwayatKelahiranController(IRiwayatKelahiranRepository repository)
        {
            _repository = repository;
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
                var riwayatKelahiran = await _repository.GetRiwayatKelahiran(dataAnakId);

                if(riwayatKelahiran == null)
                    return BadRequest("Riwayat Kelahiran Anak Tidak Ditemukan!");
                return Ok(riwayatKelahiran);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}