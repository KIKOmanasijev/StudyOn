using Microsoft.AspNetCore.Mvc;
using StudyOn.Contracts;
using StudyOn.Contracts.Requests;
using StudyOn.Data.Responses;

namespace StudyOn.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private ILoggerManager _logger;
        private IUserManager _userManager;

        public UsersController(ILoggerManager logger, IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("qwe")]
        public Response<bool> RegisterUser([FromBody] AddUserRequest request)
        {
            request.Role = "User";
            var result =_userManager.AddUser(request);
            return result;

        }
    }
}
