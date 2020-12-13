using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudyOn.Data.Models;
using StudyOn.Web.Models.Account;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace StudyOn.Web.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserManager<Users> _userManager;

        public UserController(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("users/register")]
        public IActionResult Register([System.Web.Http.FromBody] RegisterViewModel model)
        {
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
                var result = _userManager.CreateAsync(user, model.Password);
                if(result.Result.Succeeded)
                {
                    return (IActionResult)Ok();
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
