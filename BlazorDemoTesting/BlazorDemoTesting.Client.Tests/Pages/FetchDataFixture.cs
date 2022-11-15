using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorDemoTesting.Client.Pages;
using BlazorDemoTesting.Client.Services;
using BlazorDemoTesting.Shared;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace BlazorDemoTesting.Client.Tests.Pages
{
    [TestFixture]
    public class FetchDataFixture
    {
        [Test]
        public void FetchData_DataExists_ViewTableData()
        {
            var ctx = new Bunit.TestContext();

            var service = new Mock<IWeatherForecastService>();

            var item = new WeatherForecast
            {
                Date = DateTime.Now,
                Summary = "test",
                TemperatureC = 10
            };

            service.Setup(o =>
                    o.Get())
                .ReturnsAsync(new List<WeatherForecast>()
                    { item }.ToArray());

            ctx.Services.AddSingleton<IWeatherForecastService>(
                service.Object
            );

            var fetchData = ctx.RenderComponent<FetchData>();

            fetchData.MarkupMatches(@$"
<h1>Weather forecast</h1>
<p>This component demonstrates fetching data from the server.</p>
<table class=""table"">
  <thead>
    <tr>
      <th>Date</th>
      <th>Temp. (C)</th>
      <th>Temp. (F)</th>
      <th>Summary</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>{item.Date.ToString("dd/MM/yyyy")}</td>
      <td>{item.TemperatureC}</td>
      <td>{item.TemperatureF}</td>
      <td>{item.Summary}</td>
    </tr>
  </tbody>
</table>
");
        }
    }
}