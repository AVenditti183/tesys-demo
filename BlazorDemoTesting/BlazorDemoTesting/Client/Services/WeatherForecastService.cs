using System.Net.Http.Json;
using BlazorDemoTesting.Shared;
using static System.Net.WebRequestMethods;

namespace BlazorDemoTesting.Client.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]?> Get();
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient client;

        public WeatherForecastService(HttpClient client)
        {
            this.client = client;
        }

        public Task<WeatherForecast[]?> Get()
            => client.GetFromJsonAsync<WeatherForecast[]>(
                "WeatherForecast"
            );
    }
}