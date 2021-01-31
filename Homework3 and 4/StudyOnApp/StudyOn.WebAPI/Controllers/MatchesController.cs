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

        /// <summary>
        /// Endpoint getting all the matches from the database
        /// </summary>
        /// <param name="request">
        /// The request is a class which inherits from SortablePageableRequest from where we can get page size and page number needed for paging of the results,
        /// it also contains the Type parameter which can be used for searching matches based on their type
        /// </param>
        /// <returns>List of matches that match the searching parametars</returns>
        [HttpGet]
        [Route("search")]
        [AllowAnonymous]
        public Response<List<Matches>> GetMatches([FromQuery] GetMatchesRequest request)
        {
            _logger.LogInfo("request for search matches arrived");
            var result = _matchManager.GetMatches(request);
            return result;
        }

        /// <summary>
        /// Endpoint for returning the match details
        /// </summary>
        /// <param name="matchId">Indicates the id of the match we are asking details for</param>
        /// <returns>Information for the match that will be displayed on the front end</returns>
        [HttpGet]
        [Route("{matchId}")]
        [AllowAnonymous]
        public Response<MatchDetails> GetMatch([FromHeader] GeMatchByIdRequest request)
        {
            _logger.LogInfo("request for match details arrived");
            var result = _matchManager.GetMatch(request);
            return result;
        }

        /// <summary>
        /// Endpoint for returning the players of the match
        /// </summary>
        /// <param name="matchId">Indicates the id of the match for which we need the players</param>
        /// <returns>List of user information for the players of that match</returns>
        [HttpGet]
        [Route("{matchId}/players")]
        [AllowAnonymous]
        public Response<List<UserInfo>> GetMatchPlayers([FromHeader] GeMatchByIdRequest request)
        {
            _logger.LogInfo("request for match players arrived");
            var result = _matchManager.GetMatchPlayers(request);
            return result;
        }

        /// <summary>
        /// Endpoint for creating a new match
        /// </summary>
        /// <param name="request">Gathers all the needed information for a new match from the body of the request</param>
        /// <returns>Bool indicating whether or not the creation of match was successful or not</returns>
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

        /// <summary>
        /// Endpoint for joining the match
        /// </summary>
        /// <param name="request">The request contains the Id of the user and the Id of the match to which the user wants to join, we get the userId from the JWT</param>
        /// <returns>Bool indicating whether or not the joining of match was successful or not</returns>
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


    }
}
