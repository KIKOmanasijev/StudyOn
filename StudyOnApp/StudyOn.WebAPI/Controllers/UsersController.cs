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
        [Route("register")]
        public Response<bool> RegisterUser([FromBody] AddUserRequest request)
        {
            request.Role = 0;
            var result =_userManager.AddUser(request);
            return result;

        }

        [HttpGet]
        [Route("login")]
        public Response<bool> Login([FromBody] LoginRequest request)
        {
            var result = _userManager.SignInUser(request);
            return result;
        }
    }
}
