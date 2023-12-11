using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Data.Services;
using ProyectoAPI.Data.ViewModels;
using System;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private ReservaService _reservaService;

        public ReservaController(ReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpGet("get-all-reservas")]
        public IActionResult GetAllReservas()
        {
            try
            {
                var allReservas = _reservaService.GetAllReservas();
                return Ok(allReservas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener todas las reservas: {ex.Message}");
            }
        }

        [HttpGet("get-reserva-by-id/{id}")]
        public IActionResult GetReservaById(int id)
        {
            try
            {
                var reserva = _reservaService.GetReservaById(id);
                if (reserva == null)
                    return NotFound($"No se encontró la reserva con ID {id}");

                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener la reserva con ID {id}: {ex.Message}");
            }
        }

        [HttpPost("add-reserva")]
        public IActionResult AddReserva([FromBody] ReservaVM reserva)
        {
            try
            {
                _reservaService.AddReserva(reserva);
                return Ok("Reserva agregada con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al agregar la reserva: {ex.Message}");
            }
        }

        [HttpPut("update-reserva-by-id/{id}")]
        public IActionResult UpdateReservaById(int id, [FromBody] ReservaVM reserva)
        {
            try
            {
                var updateReserva = _reservaService.UpdateReservaById(id, reserva);
                if (updateReserva == null)
                    return NotFound($"No se encontró la reserva con ID {id}");

                return Ok(updateReserva);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar la reserva con ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("delete-reserva-by-id/{id}")]
        public IActionResult DeleteReservaById(int id)
        {
            try
            {
                _reservaService.DeleteReservaById(id);
                return Ok("Reserva eliminada con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar la reserva con ID {id}: {ex.Message}");
            }
        }
    }
}
