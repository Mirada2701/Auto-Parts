using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Parts_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : Controller
    {
        private readonly IProviderService providerService;

        public ProvidersController(IProviderService providerService)
        {
            this.providerService = providerService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(providerService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(providerService.Get(id));
        }
    }
}
