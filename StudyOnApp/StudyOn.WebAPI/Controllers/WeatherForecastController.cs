using Microsoft.AspNetCore.Mvc;
using StudyOn.Contracts;
using System.Collections.Generic;

namespace StudyOn.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        public WeatherForecastController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var courts = _repoWrapper.Courts.FindAll();
            return new string[] { "value1", "value2" };
        }
    }
}
