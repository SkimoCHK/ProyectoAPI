using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Data.Services;
using ProyectoAPI.Data.ViewModels;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraController : ControllerBase
    {
        public CarreraService _carreraService;

        public CarreraController(CarreraService carreraService)
        {
            _carreraService = carreraService;
        }

        [HttpGet("get-all-carreras")]
        public IActionResult GetAllCarreras()
        {
            var allcarreras = _carreraService.GetAllCarreras();
            return Ok(allcarreras);
        }

        [HttpGet("get-carrera-by-id/{id}")]
        public IActionResult GetCarreraById(int id)
        {
            var carrera = _carreraService.GetCarreraById(id);
            return Ok(carrera);
        }

        [HttpPost("add-carrera")]
        public IActionResult AddBook([FromBody] CarreraVM carrera)
        {
            _carreraService.AddCarrera(carrera);
            return Ok();
        }
        [HttpPut("update-carrera-by-id/{id}")]
        public IActionResult UpdateCarreraById(int id, [FromBody] CarreraVM carrera)
        {
            var updateCarrera = _carreraService.UpdateCarreraById(id, carrera);
            return Ok(updateCarrera);
        }
        [HttpDelete("delete-carrera-by-id/{id}")]
        public IActionResult DeleteCarreraById(int id)
        {
            _carreraService.DeleteCarreraById(id);
            return Ok();
        }

    }
}
