using BlazorDemoTesting.Server.Repository;
using BlazorDemoTesting.Shared;

namespace BlazorDemoTesting.Server.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IRepositoryWeatherForecast repository;

        public WeatherForecastService(IRepositoryWeatherForecast repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<WeatherForecast>?> GetAsync()
        {
            var items = await repository.GetAllAsync();

            return items?.Select(
                item => new WeatherForecast
                {
                    Date = item.Date,
                    Summary = item.Summary,
                    TemperatureC = item.TemperatureC
                }
            );
        }

        public async Task AddAsync(WeatherForecast? forecast)
        {
            if (forecast == null)
                throw new ArgumentNullException();

            if (forecast.TemperatureC < -280)
                throw new ArgumentException(
                    "temperatura troppo bassa",
                    nameof(forecast.TemperatureC)
                );
            ;
            await repository.AddAsync(new WeatherForecastDataModel
            {
                Date = forecast.Date,
                Summary = forecast.Summary,
                TemperatureC = forecast.TemperatureC
            });
        }
    }
}