using BlazorDemoTesting.Server.Services;
using BlazorDemoTesting.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDemoTesting.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> logger;
        private readonly IWeatherForecastService service;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherForecastService service
        )
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet]
        public Task<IEnumerable<WeatherForecast>?> Get()
            => service.GetAsync();
    }
}