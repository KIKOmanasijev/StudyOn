using Court.Contracts.Managers;
using Court.Contracts.Requests;
using Court.Contracts.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Court.WebAPI.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class CourtsController : ControllerBase
    {
        private ILoggerManager _logger;
        private ICourtsManager _courtsManager;

        public CourtsController(ILoggerManager logger, ICourtsManager courtsManager)
        {
            _logger = logger;
            _courtsManager = courtsManager;
        }
        [HttpGet]
        [Route("search")]
        public Response<List<Contracts.Models.Courts>> GetCourts([FromQuery] GetCourtsRequest request)
        {
            var result = _courtsManager.GetCourt(request);
            return result;
        }
        [HttpPost]
        [Route("review/{CourtId}")]
        public Response<bool> ReviewCourt(decimal CourtId ,[FromBody]ReviewCourtRequest request)
        {
            request.CourtId = CourtId;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(identity!=null)
            {
                request.UserId = identity.FindFirst("jti").Value;
            }
            var result = _courtsManager.ReviewCourt(request);
            return result;
        }
    }
}
