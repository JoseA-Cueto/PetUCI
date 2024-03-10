using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetUci.InterfacesBussines;
using PetUci.ViewModels;

namespace PetUci.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;

        public TreatmentController(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreatmentViewModel>>> GetTreatments()
        {
            try
            {
                var treatments = await _treatmentService.GetTreatmentsAsync();
                return Ok(treatments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<TreatmentViewModel>> GetTreatment(int id)
        {
            try
            {
                var treatment = await _treatmentService.GetTreatmentByIdAsync(id);
                if (treatment == null)
                {
                    return NotFound();
                }
                return Ok(treatment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

       
        [HttpPost]
        public async Task<ActionResult<int>> PostTreatment([FromBody] TreatmentViewModel treatmentViewModel)
        {
            try
            {
                await _treatmentService.AddTreatmentAsync(treatmentViewModel);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreatment(int id, [FromBody] TreatmentViewModel treatmentViewModel)
        {
            try
            {
                if (id != treatmentViewModel.Id)
                {
                    return BadRequest();
                }

                await _treatmentService.UpdateTreatmentAsync(treatmentViewModel);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreatment(int id)
        {
            try
            {
                await _treatmentService.DeleteTreatmentAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
