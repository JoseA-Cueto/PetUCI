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
    [Route("api/Forum")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService;
        private readonly ILogger<ForumController> _logger;

        public ForumController(IForumService forumService, ILogger<ForumController> logger)
        {
            _forumService = forumService;
            _logger = logger;
        }

        [HttpGet("GetAllForums")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ForumViewModel>>> GetAllForums()
        {
            try
            {
                var forums = await _forumService.GetForumsAsync();
                return Ok(forums);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los foros");
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpGet("GetForumById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ForumViewModel>> GetForumById(int id)
        {
            try
            {
                var forum = await _forumService.GetForumByIdAsync(id);
                if (forum == null)
                {
                    return NotFound();
                }
                return Ok(forum);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el foro con ID: {id}");
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpPost("AddForum")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddForum([FromBody] ForumViewModel forumViewModel)
        {
            try
            {
                var id = await _forumService.AddForumAsync(forumViewModel);
                return CreatedAtAction(nameof(GetForumById), new { id = id }, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar un nuevo foro");
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateForum/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateForum(int id, [FromBody] ForumViewModel forumViewModel)
        {
            try
            {
                var existingForum = await _forumService.GetForumByIdAsync(id);
                if (existingForum == null)
                {
                    return NotFound();
                }

                await _forumService.UpdateForumAsync(forumViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el foro con ID: {id}");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteForum/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteForum(int id)
        {
            try
            {
                var existingForum = await _forumService.GetForumByIdAsync(id);
                if (existingForum == null)
                {
                    return NotFound();
                }

                await _forumService.DeleteForumAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el foro con ID: {id}");
                return StatusCode(500);
            }
        }
    }
}

