using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Data.Services;
using ProyectoAPI.Data.ViewModels;
using System;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstalacionController : ControllerBase
    {
        public InstalacionService _instalacionService;

        public InstalacionController(InstalacionService instalacionService)
        {
            _instalacionService = instalacionService;
        }

        [HttpGet("get-all-instalaciones")]
        public IActionResult GetAllInstalaciones()
        {
            try
            {
                var allInstalaciones = _instalacionService.GetAllInstalaciones();
                return Ok(allInstalaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener todas las instalaciones: {ex.Message}");
            }
        }

        [HttpGet("get-instalacion-by-id/{id}")]
        public IActionResult GetInstalacionById(int id)
        {
            try
            {
                var instalacion = _instalacionService.GetInstalacionById(id);
                if (instalacion == null)
                    return NotFound($"No se encontró la instalación con ID {id}");

                return Ok(instalacion);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener la instalación con ID {id}: {ex.Message}");
            }
        }

        [HttpPost("add-instalacion")]
        public IActionResult AddInstalacion([FromBody] InstalacionVM instalacion)
        {
            try
            {
                _instalacionService.AddInstalacion(instalacion);
                return Ok("Instalación agregada con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al agregar la instalación: {ex.Message}");
            }
        }

        [HttpPut("update-instalacion-by-id/{id}")]
        public IActionResult UpdateInstalacionById(int id, [FromBody] InstalacionVM instalacion)
        {
            try
            {
                var updateInstalacion = _instalacionService.UpdateInstalacionById(id, instalacion);
                if (updateInstalacion == null)
                    return NotFound($"No se encontró la instalación con ID {id}");

                return Ok(updateInstalacion);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar la instalación con ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("delete-instalacion-by-id/{id}")]
        public IActionResult DeleteInstalacionById(int id)
        {
            try
            {
                _instalacionService.DeleteInstalacionById(id);
                return Ok("Instalación eliminada con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar la instalación con ID {id}: {ex.Message}");
            }
        }
    }
}
