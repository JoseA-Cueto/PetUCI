using Microsoft.AspNetCore.Mvc;

namespace PetUci.Controllers
{
    using global::PetUci.InterfacesBussines;
    using global::PetUci.Models;
    using global::PetUci.Services;
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
            private readonly IImageFileService _imageFileService;

            public PetController(IPetService petService, ILogger<PetController> logger, IImageFileService imageFileService)
            {
                _petService = petService;
                _logger = logger;
                _imageFileService = imageFileService;
            }

            [HttpGet("GetAllPets")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<IEnumerable<PetViewModel>>> GetAllPets()
            {
                try
                {
                    var pets = await _petService.GetPetAsync();

                    foreach (var pet in pets)
                    {
                        try
                        {
                            var imageFile = await _imageFileService.GetImageByPetIdAsync(pet.id);
                            if (imageFile != null)
                            {
                                pet.ImagePath = imageFile.Path;
                            }
                        }
                        catch (Exception ex)
                        {
                            // Manejo de errores si es necesario
                            _logger.LogError(ex, $"Error al asignar el Path de imagen para el mascota {pet.id}");
                        }
                    }

                    return Ok(pets);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al obtener todas las mascotas");
                    return StatusCode(500); // Devuelve un código de estado 500 en caso de error
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
                    if (pet != null)
                    {
                        var imageFile = await _imageFileService.GetImageByPetIdAsync(pet.id);
                        if (imageFile != null)
                        {
                            pet.ImagePath = imageFile.Path;
                        }
                    }
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
            public async Task<ActionResult> AddPet([FromForm] PetViewModel petViewModel)
            {
                try
                {
                    if (petViewModel.File == null || petViewModel.File.Length == 0)
                    {
                        return BadRequest("No se ha proporcionado ninguna imagen.");
                    }


                     await _petService.AddPetAsync(petViewModel);                    
                    await _imageFileService.CreateImageFileByPet(petViewModel);
                    return StatusCode(201);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al agregar un nuevo producto con imagen.");
                    return StatusCode(500);
                }
            }

            [HttpPut("UpdatePet")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult> UpdatePet( [FromForm] PetViewModel petViewModel)
            {
                try
                {
                    if (petViewModel.File == null || petViewModel.File.Length == 0)
                    {
                        return BadRequest("No se ha proporcionado ninguna imagen.");
                    }

                    await _petService.UpdatePetAsync(petViewModel);
                    await _imageFileService.UpdateImageFileByPet(petViewModel);

                    return StatusCode(200);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al actualizar la mascota con imagen.");
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
                    var existingImage = await _imageFileService.GetImageByPetIdAsync(id);
                    if (existingPet == null)
                    {
                        return NotFound();
                    }

                    await _petService.DeletePetAsync(id);
                    await _imageFileService.DeleteImageFileAsync(existingImage.Id);
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
