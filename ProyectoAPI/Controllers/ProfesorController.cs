using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Data.Services;
using ProyectoAPI.Data.ViewModels;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {

        public ProfesorService _profesorService;

        public ProfesorController(ProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        [HttpGet("get-all-profesores")]
        public IActionResult GetAllProfesores()
        {
            var allprofesores = _profesorService.GetAllProfesores();
            return Ok(allprofesores);
        }

        [HttpGet("get-profesor-by-id/{id}")]
        public IActionResult GetProfesorById(int id)
        {
            var profesor = _profesorService.GetProfesorById(id);
            return Ok(profesor);
        }

        [HttpPost("add-profesor")]
        public IActionResult AddBook([FromBody] ProfesorVM profe)
        {
            _profesorService.AddProfesor(profe);
            return Ok();
        }

        [HttpPut("update-profesor-by-id/{id}")]
        public IActionResult UpdateProfesorById(int id, [FromBody] ProfesorVM profesor)
        {
            var updateProfesor = _profesorService.UpdateProfesorById(id, profesor);
            return Ok(updateProfesor);
        }
        [HttpDelete("delete-carrera-by-id/{id}")]
        public IActionResult DeleteCarreraById(int id)
        {
            _profesorService.DeleteProfesorById(id);
            return Ok();
        }

    }
}
