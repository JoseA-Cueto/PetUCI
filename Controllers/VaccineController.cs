using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetUci.InterfacesBussines;
using PetUci.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.Controllers
{
    [Route("api/Vaccine")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly IVaccineService _vaccineService;
        private readonly ILogger<VaccineController> _logger;

        public VaccineController(IVaccineService vaccineService, ILogger<VaccineController> logger)
        {
            _vaccineService = vaccineService;
            _logger = logger;
        }

        [HttpGet("GetAllVaccines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VaccineViewModel>>> GetAllVaccines()
        {
            try
            {
                var vaccines = await _vaccineService.GetVaccinesAsync();
                return Ok(vaccines);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas las vacunas");
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpGet("GetVaccineById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VaccineViewModel>> GetVaccineById(int id)
        {
            try
            {
                var vaccine = await _vaccineService.GetVaccineByIdAsync(id);
                if (vaccine == null)
                {
                    return NotFound();
                }
                return Ok(vaccine);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener la vacuna con ID: {id}");
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpPost("AddVaccine")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddVaccine([FromBody] VaccineViewModel vaccineViewModel)
        {
            try
            {
                var id = await _vaccineService.AddVaccineAsync(vaccineViewModel);
                return CreatedAtAction(nameof(GetVaccineById), new { id = id }, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar una nueva vacuna");
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateVaccine/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateVaccine(int id, [FromBody] VaccineViewModel vaccineViewModel)
        {
            try
            {
                var existingVaccine = await _vaccineService.GetVaccineByIdAsync(id);
                if (existingVaccine == null)
                {
                    return NotFound();
                }

                await _vaccineService.UpdateVaccineAsync(vaccineViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar la vacuna con ID: {id}");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteVaccine/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteVaccine(int id)
        {
            try
            {
                var existingVaccine = await _vaccineService.GetVaccineByIdAsync(id);
                if (existingVaccine == null)
                {
                    return NotFound();
                }

                await _vaccineService.DeleteVaccineAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar la vacuna con ID: {id}");
                return StatusCode(500);
            }
        }
    }
}
