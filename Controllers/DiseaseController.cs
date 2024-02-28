using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetUci.InterfacesBussines;
using PetUci.Models;
using PetUci.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetUci.Controllers
{
    [Route("api/Disease")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseService _diseaseService;
        private readonly ILogger<DiseaseController> _logger;
        private readonly IMapper _mapper;

        public DiseaseController(IDiseaseService diseaseService, ILogger<DiseaseController> logger, IMapper mapper)
        {
            _diseaseService = diseaseService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("GetAllDiseases")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DiseaseViewModel>>> GetAllDiseases()
        {
            try
            {
                var diseases = await _diseaseService.GetDiseasesAsync();
                return Ok(diseases);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas las enfermedades");
                return StatusCode(500);
            }
        }

        [HttpGet("GetDiseaseById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DiseaseViewModel>> GetDiseaseById(int id)
        {
            try
            {
                var disease = await _diseaseService.GetDiseaseByIdAsync(id);
                if (disease == null)
                {
                    return NotFound();
                }
                return Ok(disease);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener la enfermedad con ID: {id}");
                return StatusCode(500);
            }
        }

        [HttpPost("AddDisease")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddDisease([FromBody] DiseaseViewModel diseaseViewModel)
        {
            try
            {
                // Mapear DiseaseViewModel a Disease
                var disease = _mapper.Map<Disease>(diseaseViewModel);

                var id = await _diseaseService.AddDiseaseAsync(disease);
                return CreatedAtAction(nameof(GetDiseaseById), new { id = id }, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar una nueva enfermedad");
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateDisease/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDisease(int id, [FromBody] DiseaseViewModel diseaseViewModel)
        {
            try
            {
                var existingDisease = await _diseaseService.GetDiseaseByIdAsync(id);
                if (existingDisease == null)
                {
                    return NotFound();
                }

                // Mapear el DiseaseViewModel a Disease antes de actualizar
                var disease = _mapper.Map<Disease>(diseaseViewModel);

                disease.Id = id; // Asignar el id

                await _diseaseService.UpdateDiseaseAsync(disease);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar la enfermedad con ID: {id}");
                return StatusCode(500);
            }
        }


        [HttpDelete("DeleteDisease/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDisease(int id)
        {
            try
            {
                var existingDisease = await _diseaseService.GetDiseaseByIdAsync(id);
                if (existingDisease == null)
                {
                    return NotFound();
                }

                await _diseaseService.DeleteDiseaseAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar la enfermedad con ID: {id}");
                return StatusCode(500);
            }
        }
    }
}
