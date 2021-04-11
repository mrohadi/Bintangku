using System.Threading.Tasks;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class BirthHistoryController : BaseApiController
    {
        private IBirthHistoryRepository _repository;
        public BirthHistoryController(IBirthHistoryRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// Get data riwayat kelahiran anak
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <returns>Data riwayat kelahiran anak</returns>
        [HttpGet("child-birth-history/{childDataId}")]
        public async Task<ActionResult<BirthHistory>> GetRiwayatKelahiran(int childDataId)
        {
            try
            {
                var birthHistory = await _repository.GetBirthHistoryAsync(childDataId);

                if(birthHistory == null)
                    return BadRequest("Birth History Not Found!");
                return Ok(birthHistory);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}