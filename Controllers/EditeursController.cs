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
    public class EditeurController : ControllerBase
    {
        private readonly IEditeurRepository _editeurRepository;

        public EditeurController(IEditeurRepository editeurRepository)
        {
            _editeurRepository = editeurRepository;
        }

        // GET: api/Editeur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editeur>>> GetEditeurs()
        {
            var editeurs = await _editeurRepository.GetAllEditeursAsync();
            return Ok(editeurs);
        }

        // GET: api/Editeur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editeur>> GetEditeur(int id)
        {
            var editeur = await _editeurRepository.GetEditeurByIdAsync(id);
            if (editeur == null)
            {
                return NotFound($"Editeur with ID {id} not found.");
            }
            return Ok(editeur);
        }

        // PUT: api/Editeur/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditeur(int id, Editeur editeur)
        {
            if (id != editeur.EditeurID)
            {
                return BadRequest("ID mismatch.");
            }

            try
            {
                await _editeurRepository.UpdateEditeurAsync(editeur);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        // POST: api/Editeur
        [HttpPost]
        public async Task<ActionResult<Editeur>> PostEditeur(Editeur editeur)
        {
            if (editeur == null)
            {
                return BadRequest("Editeur data is null.");
            }

            try
            {
                var createdEditeur = await _editeurRepository.AddEditeurAsync(editeur);
                return CreatedAtAction(nameof(GetEditeur), new { id = createdEditeur.EditeurID }, createdEditeur);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Editeur/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Editeur>> DeleteEditeur(int id)
        {
            try
            {
                var editeur = await _editeurRepository.GetEditeurByIdAsync(id);
                if (editeur == null)
                {
                    return NotFound($"Editeur with ID {id} not found.");
                }

                await _editeurRepository.DeleteEditeurAsync(id);
                return Ok(editeur);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
