using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Data.Services;
using ProyectoAPI.Data.ViewModels;
using System;

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
            try
            {
                var allCarreras = _carreraService.GetAllCarreras();
                return Ok(allCarreras);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener todas las carreras: {ex.Message}");
            }
        }

        [HttpGet("get-carrera-by-id/{id}")]
        public IActionResult GetCarreraById(int id)
        {
            try
            {
                var carrera = _carreraService.GetCarreraById(id);
                if (carrera == null)
                    return NotFound($"No se encontró la carrera con ID {id}");

                return Ok(carrera);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener la carrera con ID {id}: {ex.Message}");
            }
        }

        [HttpPost("add-carrera")]
        public IActionResult AddCarrera([FromBody] CarreraVM carrera)
        {
            try
            {
                _carreraService.AddCarrera(carrera);
                return Ok("Carrera agregada con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al agregar la carrera: {ex.Message}");
            }
        }

        [HttpPut("update-carrera-by-id/{id}")]
        public IActionResult UpdateCarreraById(int id, [FromBody] CarreraVM carrera)
        {
            try
            {
                var updateCarrera = _carreraService.UpdateCarreraById(id, carrera);
                if (updateCarrera == null)
                    return NotFound($"No se encontró la carrera con ID {id}");

                return Ok(updateCarrera);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar la carrera con ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("delete-carrera-by-id/{id}")]
        public IActionResult DeleteCarreraById(int id)
        {
            try
            {
                _carreraService.DeleteCarreraById(id);
                return Ok("Carrera eliminada con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar la carrera con ID {id}: {ex.Message}");
            }
        }
    }
}
