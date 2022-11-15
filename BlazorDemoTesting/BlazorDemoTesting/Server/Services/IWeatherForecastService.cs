using BlazorDemoTesting.Shared;

namespace BlazorDemoTesting.Server.Services;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecast>?> GetAsync();
    Task AddAsync(WeatherForecast? forecast);
}