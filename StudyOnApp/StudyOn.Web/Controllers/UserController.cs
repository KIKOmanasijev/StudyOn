using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudyOn.Data.Models;
using StudyOn.Web.Models.Account;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using HttpPost = System.Web.Http.HttpPostAttribute;
using Route = System.Web.Http.RouteAttribute;

namespace StudyOn.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;

        public UserController(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("users/register")]
        public async Task<IActionResult> Register([System.Web.Http.FromBody] RegisterViewModel model)
        {
            return (IActionResult)Ok("success!");
            if (ModelState.IsValid)
            {
                var user = new Users
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    Role = "User"

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    return (IActionResult)Ok("success!");
                }
                else
                {
                    return (IActionResult)BadRequest();
                }
            }
            else
            {
                return (IActionResult)BadRequest();
            }
        }
    }
}
