using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyOn.Contracts;
using StudyOn.Contracts.Managers;
using StudyOn.Contracts.Requests;
using StudyOn.Data.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
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
        public Response<bool> RegisterUser([FromBody] AddMatchRequest request)
        {
            var result = _matchManager.AddMatch(request);
            return result;
        }
        [HttpPost]
        [Route("join")]
        public Response<bool> RegisterUser([FromBody] JoinMatchRequest request)
        {
            var result = _matchManager.JoinMatch(request);
            return result;
        }
    }
}
