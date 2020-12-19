using Microsoft.AspNetCore.Mvc;
using StudyOn.Contracts;
using StudyOn.Contracts.Requests;
using System;

namespace StudyOn.WebAPI.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        public UsersController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        [Route("users")]
        public IActionResult RegisterUser([FromBody] AddUserRequest request)
        {
            request.Role = "User";
            try
            {
                _logger.LogInfo($"Returned all owners from database.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
