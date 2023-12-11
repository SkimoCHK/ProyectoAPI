// InstalacionController.cs

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Data.Services;
using ProyectoAPI.Data.ViewModels;

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
            var allInstalaciones = _instalacionService.GetAllInstalaciones();
            return Ok(allInstalaciones);
        }

        [HttpGet("get-instalacion-by-id/{id}")]
        public IActionResult GetInstalacionById(int id)
        {
            var instalacion = _instalacionService.GetInstalacionById(id);
            return Ok(instalacion);
        }

        [HttpPost("add-instalacion")]
        public IActionResult AddInstalacion([FromBody] InstalacionVM instalacion)
        {
            _instalacionService.AddInstalacion(instalacion);
            return Ok();
        }

        [HttpPut("update-instalacion-by-id/{id}")]
        public IActionResult UpdateInstalacionById(int id, [FromBody] InstalacionVM instalacion)
        {
            var updateInstalacion = _instalacionService.UpdateInstalacionById(id, instalacion);
            return Ok(updateInstalacion);
        }

        [HttpDelete("delete-instalacion-by-id/{id}")]
        public IActionResult DeleteInstalacionById(int id)
        {
            _instalacionService.DeleteInstalacionById(id);
            return Ok();
        }
    }
}
