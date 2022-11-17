using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDemoTesting.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public TitleController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var title = configuration.GetValue<string>("title");

            return Ok(title);
        }
    }
}