namespace BlazorDemoTesting.Server.Repository;

public class RepositoryWeatherForecast : IRepositoryWeatherForecast
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task AddAsync(WeatherForecastDataModel weatherForecast)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<WeatherForecastDataModel>?> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<WeatherForecastDataModel>?>(Enumerable.Range(1, 5).Select(index => new WeatherForecastDataModel
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }));
    }
}