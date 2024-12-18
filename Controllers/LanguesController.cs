using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LangueController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LangueController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Langue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Langue>>> GetLangues()
        {
            return await _context.Langues.ToListAsync();
        }

        // GET: api/Langue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Langue>> GetLangue(int id)
        {
            var langue = await _context.Langues.FindAsync(id);

            if (langue == null)
            {
                return NotFound();
            }

            return langue;
        }

        // PUT: api/Langue/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLangue(int id, Langue langue)
        {
            if (id != langue.LangueID)
            {
                return BadRequest();
            }

            _context.Entry(langue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LangueExists(id))
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

        // POST: api/Langue
        [HttpPost]
        public async Task<ActionResult<Langue>> PostLangue(Langue langue)
        {
            _context.Langues.Add(langue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLangue", new { id = langue.LangueID }, langue);
        }

        // DELETE: api/Langue/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Langue>> DeleteLangue(int id)
        {
            var langue = await _context.Langues.FindAsync(id);
            if (langue == null)
            {
                return NotFound();
            }

            _context.Langues.Remove(langue);
            await _context.SaveChangesAsync();

            return langue;
        }

        private bool LangueExists(int id)
        {
            return _context.Langues.Any(e => e.LangueID == id);
        }
    }
}
