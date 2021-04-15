using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bintangku.WebApi.Data;
using Bintangku.WebApi.Data.Entities;

namespace Bintangku.WebApi.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly ApplicationDataContext _dataContext;
        public BuggyController(ApplicationDataContext dataContext)
        {
            _dataContext = dataContext;

        } 

        /// <summary>
        /// Test 401 unauthorized responses
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("buggy/auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret text";
        }

        /// <summary>
        /// Test 404 Not Found responses
        /// </summary>
        /// <returns></returns>
        [HttpGet("buggy/not-found")]
        public ActionResult<NakesUser> GetNotFound()
        {
            var thing = _dataContext.Users.Find(-1);

            if (thing == null) return NotFound();

            return Ok(thing);
        }

        /// <summary>
        /// Test 500 Internal Server error response
        /// </summary>
        /// <returns></returns>
        [HttpGet("buggy/server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = _dataContext.Users.Find(-1);

            var thingToReturn = thing.ToString();

            return thingToReturn;
        }

        /// <summary>
        /// Test Bad Request responses
        /// </summary>
        /// <returns></returns>
        [HttpGet("buggy/bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}