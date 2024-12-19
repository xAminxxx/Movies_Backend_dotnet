using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // You can further specify roles, e.g. [Authorize(Roles = "Admin")]
    public class LangueController : ControllerBase
    {
        private readonly ILangueRepository _langueRepository;

        public LangueController(ILangueRepository langueRepository)
        {
            _langueRepository = langueRepository;
        }

        // GET: api/Langue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Langue>>> GetLangues()
        {
            var langues = await _langueRepository.GetAllLanguesAsync();
            return Ok(langues);
        }

        // GET: api/Langue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Langue>> GetLangue(int id)
        {
            var langue = await _langueRepository.GetLangueByIdAsync(id);
            if (langue == null)
            {
                return NotFound($"Langue with ID {id} not found.");
            }
            return Ok(langue);
        }

        // PUT: api/Langue/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLangue(int id, Langue langue)
        {
            if (id != langue.LangueID)
            {
                return BadRequest("ID mismatch.");
            }

            try
            {
                await _langueRepository.UpdateLangueAsync(langue);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        // POST: api/Langue
        [HttpPost]
        public async Task<ActionResult<Langue>> PostLangue(Langue langue)
        {
            if (langue == null)
            {
                return BadRequest("Langue data is null.");
            }

            try
            {
                var createdLangue = await _langueRepository.AddLangueAsync(langue);
                return CreatedAtAction(nameof(GetLangue), new { id = createdLangue.LangueID }, createdLangue);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Langue/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Langue>> DeleteLangue(int id)
        {
            try
            {
                var langue = await _langueRepository.GetLangueByIdAsync(id);
                if (langue == null)
                {
                    return NotFound($"Langue with ID {id} not found.");
                }

                await _langueRepository.DeleteLangueAsync(id);
                return Ok(langue);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
