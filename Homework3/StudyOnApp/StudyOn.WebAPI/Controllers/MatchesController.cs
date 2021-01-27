using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyOn.Contracts.Managers;
using StudyOn.Contracts.Models;
using StudyOn.Contracts.Requests;
using StudyOn.Contracts.Responses;
using System.Collections.Generic;
using System.Security.Claims;

namespace StudyOn.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class MatchesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IMatchManager _matchManager;

        public MatchesController(ILoggerManager logger, IMatchManager matchManager)
        {
            _logger = logger;
            _matchManager = matchManager;
        }

        [HttpPost]
        [Route("create")]
        public Response<bool> AddMatch([FromBody] AddMatchRequest request)
        {
            _logger.LogInfo("request for new match arrived");
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                request.UserId = identity.FindFirst("jti").Value;
            }
            var result = _matchManager.AddMatch(request);
            return result;
        }
        [HttpPost]
        [Route("join")]
        public Response<bool> JoinMatch([FromBody] JoinMatchRequest request)
        {
            _logger.LogInfo("request for join match arrived");
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                request.UserId = identity.FindFirst("jti").Value;
            }
            var result = _matchManager.JoinMatch(request);
            return result;
        }

        [HttpGet]
        [Route("search")]
        [AllowAnonymous]
        public Response<List<Matches>> GetMatches([FromQuery] GetMatchesRequest request)
        {
            _logger.LogInfo("request for search matches arrived");
            var result = _matchManager.GetMatches(request);
            return result;
        }

        [HttpGet]
        [Route("{matchId}")]
        [AllowAnonymous]
        public Response<MatchDetails> GetMatch([FromHeader] GeMatchByIdRequest request)
        {
            _logger.LogInfo("request for match details arrived");
            var result = _matchManager.GetMatch(request);
            return result;
        }
    }
}
