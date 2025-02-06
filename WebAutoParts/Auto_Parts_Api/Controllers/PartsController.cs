using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Parts_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : Controller
    {
        private readonly IPartsService _partsService;
        public PartsController(IPartsService _partsService)
        {
            this._partsService = _partsService;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_partsService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_partsService.Get(id));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _partsService.Delete(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Create(CreateSparePartDto model)
        {
            _partsService.Create(model);
            return Ok();
        }
        [HttpPut]
        public IActionResult Edit(EditSparePartDto model)
        {
            _partsService.Edit(model);
            return Ok();
        }
    }
}
