using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Worker.Italia.Entities;
using Worker.Italia.Services.Lazio;

namespace Worker.Italia.PublicApi.Lazio
{
    [ApiController]
    [Route("api/public/[Controller]")]
    public class LazioController : Controller
    {
        private readonly ILazioService service;

        public LazioController(ILazioService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Post(PostLazioModel model)
        {
            var entity = new LazioEntity()
            {
                Name = model.Name,
                LastName = model.LastName
            };

            service.SendCreateEntityCommand(entity);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = service.GetAll();

            return Ok(entities.Select(entity =>
                new GetLazioModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    LastName = entity.LastName
                }
            ));
        }
    }
}