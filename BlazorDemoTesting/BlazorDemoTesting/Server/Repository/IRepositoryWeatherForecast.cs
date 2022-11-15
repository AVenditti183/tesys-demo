namespace BlazorDemoTesting.Server.Repository
{
    public interface IRepositoryWeatherForecast
    {
        Task<IEnumerable<WeatherForecastDataModel>?> GetAllAsync();

        Task AddAsync(WeatherForecastDataModel weatherForecast);
    }
}