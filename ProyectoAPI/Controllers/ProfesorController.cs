using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Data.Services;
using ProyectoAPI.Data.ViewModels;
using System;

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
            try
            {
                var allProfesores = _profesorService.GetAllProfesores();
                return Ok(allProfesores);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener todos los profesores: {ex.Message}");
            }
        }

        [HttpGet("get-profesor-by-id/{id}")]
        public IActionResult GetProfesorById(int id)
        {
            try
            {
                var profesor = _profesorService.GetProfesorById(id);
                if (profesor == null)
                    return NotFound($"No se encontró el profesor con ID {id}");

                return Ok(profesor);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener el profesor con ID {id}: {ex.Message}");
            }
        }

        [HttpPost("add-profesor")]
        public IActionResult AddProfesor([FromBody] ProfesorVM profesor)
        {
            try
            {
                _profesorService.AddProfesor(profesor);
                return Ok("Profesor agregado con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al agregar el profesor: {ex.Message}");
            }
        }

        [HttpPut("update-profesor-by-id/{id}")]
        public IActionResult UpdateProfesorById(int id, [FromBody] ProfesorVM profesor)
        {
            try
            {
                var updateProfesor = _profesorService.UpdateProfesorById(id, profesor);
                if (updateProfesor == null)
                    return NotFound($"No se encontró el profesor con ID {id}");

                return Ok(updateProfesor);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el profesor con ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("delete-profesor-by-id/{id}")]
        public IActionResult DeleteProfesorById(int id)
        {
            try
            {
                _profesorService.DeleteProfesorById(id);
                return Ok("Profesor eliminado con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el profesor con ID {id}: {ex.Message}");
            }
        }
    }
}
