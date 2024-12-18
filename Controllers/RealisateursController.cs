using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RealisateursController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RealisateursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Realisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Realisateurs>>> GetRealisateurs()
        {
            return await _context.Realisateurs.ToListAsync();
        }

        // GET: api/Realisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Realisateurs>> GetRealisateur(int id)
        {
            var realisateur = await _context.Realisateurs.FindAsync(id);

            if (realisateur == null)
            {
                return NotFound();
            }

            return realisateur;
        }

        // PUT: api/Realisateurs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRealisateur(int id, Realisateurs realisateur)
        {
            if (id != realisateur.RealisateursID)
            {
                return BadRequest();
            }

            _context.Entry(realisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealisateurExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Realisateurs
        [HttpPost]
        public async Task<ActionResult<Realisateurs>> PostRealisateur(Realisateurs realisateur)
        {
            _context.Realisateurs.Add(realisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRealisateur", new { id = realisateur.RealisateursID }, realisateur);
        }

        // DELETE: api/Realisateurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Realisateurs>> DeleteRealisateur(int id)
        {
            var realisateur = await _context.Realisateurs.FindAsync(id);
            if (realisateur == null)
            {
                return NotFound();
            }

            _context.Realisateurs.Remove(realisateur);
            await _context.SaveChangesAsync();

            return realisateur;
        }

        private bool RealisateurExists(int id)
        {
            return _context.Realisateurs.Any(e => e.RealisateursID == id);
        }
    }
}
