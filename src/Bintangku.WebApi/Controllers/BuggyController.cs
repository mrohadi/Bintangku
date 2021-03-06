using Bintangku.Data;
using Bintangku.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret text";
        }

        /// <summary>
        /// Test 404 Not Found responses
        /// </summary>
        /// <returns></returns>
        [HttpGet("not-found")]
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
        [HttpGet("server-error")]
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
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}