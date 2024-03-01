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

            public PetController(IPetService petService)
            {
                _petService = petService;
            }

            [HttpGet("GetAllPets")]
           
            public async Task<IActionResult> GetAllPets()
            {
                try
                {
                    var pets = await _petService.GetPetAsync();
                    return Ok(pets);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpGet("GetPetById/{id}")]
            public async Task<IActionResult> GetPetById(int id)
            {
                try
                {
                    var pet = await _petService.GetPetByIdAsync(id);
                    if (pet == null)
                        return NotFound($"Pet with id {id} was not found.");

                    return Ok(pet);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpPost("AddPet")]
            
            public async Task<IActionResult> AddPet([FromBody] PetViewModel petViewModel)
            {
                try
                {
                    if (petViewModel == null)
                        return BadRequest("Pet data is null.");

                    await _petService.AddPetAsync(petViewModel);
                    return CreatedAtAction(nameof(GetPetById), new { id = petViewModel.id }, petViewModel);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpPut("UpdatePet/{id}")]
 
            public async Task<IActionResult> UpdatePet(int id, [FromBody] PetViewModel petViewModel)
            {
                try
                {
                    var existingPet = await _petService.GetPetByIdAsync(id);
                    if (existingPet == null)
                        return NotFound($"Pet with id {id} was not found.");

                    petViewModel.id = id;
                    await _petService.UpdatePetAsync(petViewModel);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpDelete("DeletePet/{id}")]
           
            public async Task<IActionResult> DeletePet(int id)
            {
                try
                {
                    var existingPet = await _petService.GetPetByIdAsync(id);
                    if (existingPet == null)
                        return NotFound($"Pet with id {id} was not found.");

                    await _petService.DeletePetAsync(id);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }
    }

}
