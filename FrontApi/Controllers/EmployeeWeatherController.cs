using FrontApi.Interfaces;
using FrontApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeWeatherController : ControllerBase
    {
        private readonly ILogger<EmployeeWeatherController> _logger;
        private readonly IApi2Client _api2Client;
        private readonly IApi3Client _api3Client;

        public EmployeeWeatherController(ILogger<EmployeeWeatherController> logger, 
            IApi2Client api2Client, IApi3Client api3Client)
        {
            _logger = logger;
            _api2Client = api2Client;
            _api3Client = api3Client;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<EmployeeWeather>> Get()
        {
            IEnumerable<WeatherForecast>? forecasts = null;
            Employee employee = await _api3Client.GetEmployee(1);

            var tasks = new Task[]
            {
                Task.Run(async () => forecasts = await _api2Client.GetForecasts()),
                Task.Run(async () => employee = await _api3Client.GetEmployee(1))

            };

            await Task.WhenAll(tasks);

            return Ok(new EmployeeWeather()
            {
                Forecasts = forecasts,
                Employee = employee
            });
        }

        // NOTE: Supporting POST (add) calls would be a matter of making sure
        // that both API calls succeeded or neither calls succeed

        // This could be accomplished by running calls to both API's in order
        // with a transaction if one entity needed to be added before the other
    }
}