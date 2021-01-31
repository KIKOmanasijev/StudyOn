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

        /// <summary>
        /// Endpoint getting all the courts from the database
        /// </summary>
        /// <param name="request">
        /// The request is a class which inherits from SortablePageableRequest from where we can get page size and page number needed for paging of the results,
        /// it also contains the Type and Name parameter which can be used for searching matches based on their type or name
        /// </param>
        /// <returns>List of courts that match the searching parametars</returns>
        [HttpGet]
        [Route("search")]
        public Response<List<Contracts.Models.Courts>> GetCourts([FromQuery] GetCourtsRequest request)
        {
            _logger.LogInfo("request for search courts arrived");
            var result = _courtsManager.GetCourts(request);
            return result;
        }

        /// <summary>
        /// Endpoint for returning the court details
        /// </summary>
        /// <param name="courtId">Indicates the id of the court we are asking details for</param>
        /// <returns>Information for the court that will be displayed on the front end</returns>
        [HttpGet]
        [Route("{courtId}")]
        public Response<CourtDetails> GetCourt([FromHeader] GetCourtByIdRequest request)
        {
            _logger.LogInfo("request for court details arrived");
            var result = _courtsManager.GetCourt(request);
            return result;
        }

        /// <summary>
        /// Endpoint for rating the court
        /// </summary>
        /// <param name="request">The request contains the Id of the user and the Id of the court which the user is rating, we get the userId from the JWT
        /// also the request contains the comment and rate the user is leaving for that court
        /// </param>
        /// <returns>Bool indicating whether or not the rating of court was successful or not</returns>
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

        /// <summary>
        /// Endpoint for returning the ratings of the court
        /// </summary>
        /// <param name="courtId">Indicates the id of the court for which we need the ratings</param>
        /// <returns>List of rating information for the court</returns>
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
