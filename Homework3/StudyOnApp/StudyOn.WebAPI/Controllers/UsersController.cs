using Microsoft.AspNetCore.Mvc;
using StudyOn.Contracts;
using StudyOn.Contracts.Managers;
using StudyOn.Contracts.Requests;
using StudyOn.Contracts.Responses;

namespace StudyOn.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IUserManager _userManager;

        public UsersController(ILoggerManager logger, IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        /// <summary>
        /// Endpoint for signing up a new user in the application
        /// </summary>
        /// <param name="request">Contains all the information from the sign up form needed for a registering a new user</param>
        /// <returns>Bool indicating whether or not the registration was successful or not</returns>
        [HttpPost]
        [Route("register")]
        public Response<bool> RegisterUser([FromBody] AddUserRequest request)
        {
            _logger.LogInfo("request for register arrived");
            request.Role = 0;
            var result =_userManager.AddUser(request);
            return result;

        }
        /// <summary>
        /// Endpoint for sign in of a user into the aplication
        /// </summary>
        /// <param name="request">Contains username and password needed for a succesfull sign in into the application</param>
        /// <returns>Jason Web Token which will be used in the frontend for authorization and authentication in other endpoints</returns>
        [HttpPost]
        [Route("login")]
        public Response<LoggedInUserResponse> Login([FromBody] LoginRequest request)
        {
            _logger.LogInfo("request for login arrived");
            var result = _userManager.SignInUser(request);
            return result;
        }
    }
}
