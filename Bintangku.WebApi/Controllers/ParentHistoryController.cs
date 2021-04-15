using System.Linq;
using System.Threading.Tasks;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bintangku.WebApi.Controllers
{
    [Authorize]
    public class ParentHistoryController : BaseApiController
    {
        private IParentHistoryRepository _repository;
        private ApplicationDataContext _context;
        public ParentHistoryController(
            IParentHistoryRepository repository, ApplicationDataContext context)
        {
            _context = context;
            _repository = repository;
        }
        
        /// <summary>
        /// Get parent history
        /// </summary>
        /// <param name="childDataId">Unique childDataId</param>
        /// <returns>Parent history</returns>
        [HttpGet("parent-history/{childDataId}")]
        public async Task<ActionResult<ParentHistory>> GetParentHistoryAsync(int childDataId)
        {
            try
            {
                var parentHistory = await _repository.GetParentHistoryAsync(childDataId);

                if (parentHistory == null)
                    return BadRequest("Riwayat Orang Tua Tidak Ditemukan");
                return Ok(parentHistory);
            }
            catch (System.Exception)
            {
                throw;
            }    
        }
    }
}