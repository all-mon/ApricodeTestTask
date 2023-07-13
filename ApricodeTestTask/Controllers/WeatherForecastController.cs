using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ApricodeTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public WeatherForecastController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            

            return new string[] { "value1", "value2" };
        }
    }
}