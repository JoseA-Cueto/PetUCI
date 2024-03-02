using Microsoft.AspNetCore.Mvc;

namespace PetUci.Controllers
{
    using global::PetUci.InterfacesBussines;
    using global::PetUci.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace PetUci.Controllers
    {
        [ApiController]
        [Route("api/Pet")]
        public class PetController : ControllerBase
        {
            private readonly IPetService _petService;
            private readonly ILogger<PetController> _logger;

            public PetController(IPetService petService, ILogger<PetController> logger)
            {
                _petService = petService;
                _logger = logger;
            }

            [HttpGet("GetAllPets")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<IEnumerable<PetViewModel>>> GetAllPets()
            {
                try
                {
                    var pets = await _petService.GetPetAsync();
                    return Ok(pets);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al obtener todas las macotas");
                    return StatusCode(500);
                }
            }

            [HttpGet("GetPetById/{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<PetViewModel>> GetPetById(int id)
            {
                try
                {
                    var pet = await _petService.GetPetByIdAsync(id);
                    if (pet == null)
                    {
                        return NotFound();
                    }
                    return Ok(pet);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error al obtener la mascota con ID: {id}");
                    return StatusCode(500);
                }
            }

            [HttpPost("AddPet")]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> AddPet([FromBody] PetViewModel petViewModel)
            {
                try
                {
                    await _petService.AddPetAsync(petViewModel);
                    return StatusCode(201);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al agregar una nueva mascota");
                    return StatusCode(500);
                }
            }

            [HttpPut("UpdatePet/{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> UpdatePet(int id, [FromBody] PetViewModel petViewModel)
            {
                try
                {
                    var existingPet = await _petService.GetPetByIdAsync(id);
                    if (existingPet == null)
                    {
                        return NotFound();
                    }

                    await _petService.UpdatePetAsync(petViewModel);
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error al actualizar la mascota con ID: {id}");
                    return StatusCode(500);
                }
            }

            [HttpDelete("DeletePet/{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> DeletePet(int id)
            {
                try
                {
                    var existingPet = await _petService.GetPetByIdAsync(id);
                    if (existingPet == null)
                    {
                        return NotFound();
                    }

                    await _petService.DeletePetAsync(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error al eliminar la mascota con ID: {id}");
                    return StatusCode(500);
                }
            }
        }

    }
}
