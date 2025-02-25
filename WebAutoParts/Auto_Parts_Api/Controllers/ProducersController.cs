using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Parts_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducersController(IProducerService producerService)
        {
            this._producerService = producerService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_producerService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_producerService.Get(id));
        }
    }
}
