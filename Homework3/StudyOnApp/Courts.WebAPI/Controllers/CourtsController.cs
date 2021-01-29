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
            _logger.LogInfo("request for search courts arrived");
            var result = _courtsManager.GetCourts(request);
            return result;
        }
        [HttpPost]
        [Route("review/{CourtId}")]
        public Response<bool> ReviewCourt(decimal CourtId ,[FromBody]ReviewCourtRequest request)
        {
            _logger.LogInfo("request for review of court arrived");
            request.CourtId = CourtId;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(identity!=null)
            {
                request.UserId = identity.FindFirst("jti").Value;
            }
            var result = _courtsManager.ReviewCourt(request);
            return result;
        }

        [HttpGet]
        [Route("{courtId}")]
        public Response<CourtDetails> GetCourt([FromHeader] GetCourtByIdRequest request)
        {
            _logger.LogInfo("request for court details arrived");
            var result = _courtsManager.GetCourt(request);
            return result;
        }

        [HttpGet]
        [Route("{courtId}/ratings")]
        public Response<List<UserRatings>> GetCourtRatings([FromHeader] GetCourtByIdRequest request)
        {
            _logger.LogInfo("request for court ratings arrived");
            var result = _courtsManager.GetCourtRatings(request);
            return result;
        }
    }
}
