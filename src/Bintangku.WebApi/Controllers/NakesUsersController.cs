using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bintangku.Data;
using Bintangku.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bintangku.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NakesUsersController : ControllerBase
    {
        private readonly ApplicationDataContext _context;
        public NakesUsersController(ApplicationDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Http get method to get nakes user data from database
        /// </summary>
        /// <returns>List of nakes users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NakesUser>>> GetNakesUsers()
        {
            return await _context.NakesUsers.ToListAsync();
        }

        /// <summary>
        /// api/nakesusers/1
        /// </summary>
        /// <param name="id">id of specific nakes user</param>
        /// <returns>nakes user based on given id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<NakesUser>> GetNakesUser(int id)
        {
            return await _context.NakesUsers.FindAsync(id);
        }
    }
}