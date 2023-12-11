using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Data.Services;
using ProyectoAPI.Data.ViewModels;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdificioController : ControllerBase
    {

        public EdificioService _edificioService;

        public EdificioController(EdificioService edificioService)
        {
            _edificioService = edificioService;
        }

        [HttpGet("get-all-edificios")]
        public IActionResult GetAllEdificios()
        {
            var alledificios = _edificioService.GetAllEdificios();
            return Ok(alledificios);
        }

        [HttpGet("get-edificio-by-id/{id}")]
        public IActionResult GetEdificioById(int id)
        {
            var edificio = _edificioService.GetEdificioById(id);
            return Ok(edificio);
        }

        [HttpPost("add-edificio")]
        public IActionResult AddBook([FromBody] EdificioVM edificio)
        {
            _edificioService.AddEdificio(edificio);
            return Ok();
        }
        [HttpPut("update-edificio-by-id/{id}")]
        public IActionResult UpdateEdificioById(int id, [FromBody] EdificioVM edificio)
        {
            var updateEdificio = _edificioService.UpdateEdificioById(id, edificio);
            return Ok(updateEdificio);
        }
        [HttpDelete("delete-edificio-by-id/{id}")]
        public IActionResult DeleteEdificioById(int id)
        {
            _edificioService.DeleteEdificioById(id);
            return Ok();
        }


    }
}
