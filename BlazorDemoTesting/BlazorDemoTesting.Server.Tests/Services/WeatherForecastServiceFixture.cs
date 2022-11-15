using BlazorDemoTesting.Server.Repository;
using BlazorDemoTesting.Server.Services;
using BlazorDemoTesting.Shared;
using Moq;

namespace BlazorDemoTesting.Server.Tests.Services
{
    [TestFixture]
    public class WeatherForecastServiceFixture
    {
        private WeatherForecastService service;
        private Mock<IRepositoryWeatherForecast> repository;

        [SetUp]
        public void SetUp()
        {
            repository = new Mock<IRepositoryWeatherForecast>();
            service = new WeatherForecastService(
                repository.Object
            );
        }

        [Test]
        public async Task GetAsync_WeatherForecastDataModelExists_ReturnWeatherForecastArray()
        {
            repository
                .Setup(o => o.GetAllAsync())
                .ReturnsAsync(
                    new List<WeatherForecastDataModel>
                    {
                        new WeatherForecastDataModel
                        {
                            Date = DateTime.Now,
                            Summary = "test",
                            TemperatureC = 5
                        }
                    }
                );

            var results = await service.GetAsync();

            CollectionAssert.IsNotEmpty(results);
            CollectionAssert
                .AllItemsAreInstancesOfType(
                    results,
                    typeof(WeatherForecast)
                );
        }

        [Test]
        public async Task GetAsync_WeatherForecastDataModelEmpty_ReturnWeatherForecastArrayEmpty()
        {
            repository
                .Setup(o => o.GetAllAsync())
                .ReturnsAsync(new List<WeatherForecastDataModel>());

            var results = await service.GetAsync();

            CollectionAssert.IsEmpty(results);
        }

        [Test]
        public async Task GetAsync_WeatherForecastDataModelIsNull_ReturnNull()
        {
            repository
                .Setup(o => o.GetAllAsync())
                .ReturnsAsync(() => null);

            var results = await service.GetAsync();

            Assert.IsNull(results);
        }

        [Test]
        public async Task AddAsync_ValidData_CallRepositoryAddMethod()
        {
            var item = new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = 10,
                Summary = "test"
            };

            await service.AddAsync(item);

            repository.Verify(o =>
                o.AddAsync(
                    It.Is<WeatherForecastDataModel>(
                        m =>
                            m.TemperatureC == item.TemperatureC
                            && m.Summary == item.Summary
                            && m.Date == item.Date
                    )
                ), Times.Once);
        }

        [TestCase(-1000)]
        [TestCase(-2000)]
        [TestCase(-300)]
        public async Task AddAsync_DataNotValid_ThrowArgumentsException(int temp)
        {
            var item = new WeatherForecast
            {
                Date = DateTime.Now,
                Summary = "test",
                TemperatureC = temp
            };

            Assert.ThrowsAsync<ArgumentException>(
                () =>
                    service.AddAsync(item)
            );
        }

        [Test]
        public async Task AddAsync_DataIsNull_ThrowArgumentsNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(
                () =>
                    service.AddAsync(null)
            );
        }
    }
}