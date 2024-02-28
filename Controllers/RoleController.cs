
    using global::PetUci.InterfacesBussines;
    using global::PetUci.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace PetUci.Controllers
    {
        [Route("api/Rol")]
        [ApiController]
        public class RolController : ControllerBase
        {
            private readonly IRolService _rolService;
            private readonly ILogger<RolController> _logger;

            public RolController(IRolService rolService, ILogger<RolController> logger)
            {
                _rolService = rolService;
                _logger = logger;
            }

            [HttpGet("GetAllRols")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<IEnumerable<RolViewModel>>> GetAllRols()
            {
                try
                {
                    var rols = await _rolService.GetRolAsync();
                    return Ok(rols);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al obtener todos los roles");
                    return StatusCode(500); // Devuelve un código de estado 500 en caso de error
                }
            }

            [HttpGet("GetRolById/{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<RolViewModel>> GetRolById(int id)
            {
                try
                {
                    var rol = await _rolService.GetRolByIdAsync(id);
                    if (rol == null)
                    {
                        return NotFound();
                    }
                    return Ok(rol);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error al obtener el rol con ID: {id}");
                    return StatusCode(500); // Devuelve un código de estado 500 en caso de error
                }
            }

            [HttpPost("AddRol")]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> AddRol([FromBody] RolViewModel rolViewModel)
            {
                try
                {
                    await _rolService.AddRolAsync(rolViewModel);
                    return StatusCode(201);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al agregar un nuevo rol");
                    return StatusCode(500);
                }
            }

            [HttpPut("UpdateRol/{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> UpdateRol(int id, [FromBody] RolViewModel rolViewModel)
            {
                try
                {
                    var existingRol = await _rolService.GetRolByIdAsync(id);
                    if (existingRol == null)
                    {
                        return NotFound();
                    }

                    await _rolService.UpdateRolAsync(rolViewModel);
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error al actualizar el rol con ID: {id}");
                    return StatusCode(500);
                }
            }

            [HttpDelete("DeleteRol/{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> DeleteRol(int id)
            {
                try
                {
                    var existingRol = await _rolService.GetRolByIdAsync(id);
                    if (existingRol == null)
                    {
                        return NotFound();
                    }

                    await _rolService.DeleteRolAsync(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error al eliminar el rol con ID: {id}");
                    return StatusCode(500);
                }
            }
        }
    }


