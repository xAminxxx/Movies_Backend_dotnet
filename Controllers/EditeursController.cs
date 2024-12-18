using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // You can further specify roles, e.g. [Authorize(Roles = "Admin")]
    public class EditeurController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EditeurController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Editeur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editeur>>> GetEditeurs()
        {
            try
            {
                var editeurs = await _context.Editeurs.ToListAsync();
                return Ok(editeurs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Editeur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editeur>> GetEditeur(int id)
        {
            try
            {
                var editeur = await _context.Editeurs.FindAsync(id);

                if (editeur == null)
                {
                    return NotFound($"Editeur with ID {id} not found.");
                }

                return Ok(editeur);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Editeur/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditeur(int id, Editeur editeur)
        {
            if (id != editeur.EditeurID)
            {
                return BadRequest("ID mismatch.");
            }

            _context.Entry(editeur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditeurExists(id))
                {
                    return NotFound($"Editeur with ID {id} not found.");
                }
                else
                {
                    return StatusCode(500, "Error updating the Editeur.");
                }
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
                _context.Editeurs.Add(editeur);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEditeur), new { id = editeur.EditeurID }, editeur);
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
                var editeur = await _context.Editeurs.FindAsync(id);
                if (editeur == null)
                {
                    return NotFound($"Editeur with ID {id} not found.");
                }

                _context.Editeurs.Remove(editeur);
                await _context.SaveChangesAsync();

                return Ok(editeur);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool EditeurExists(int id)
        {
            return _context.Editeurs.Any(e => e.EditeurID == id);
        }
    }
}
