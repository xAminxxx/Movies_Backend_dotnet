using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FilmController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FilmController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Film
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> GetFilms()
        {
            return await _context.Films.Include(f => f.Categories)
                                       .Include(f => f.ActeurP)
                                       .Include(f => f.Editeur)
                                       .Include(f => f.Langues)
                                       .Include(f => f.Realisateur)
                                       .ToListAsync();
        }

        // GET: api/Film/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            var film = await _context.Films.Include(f => f.Categories)
                                           .Include(f => f.ActeurP)
                                           .Include(f => f.Editeur)
                                           .Include(f => f.Langues)
                                           .Include(f => f.Realisateur)
                                           .FirstOrDefaultAsync(f => f.FilmID == id);

            if (film == null)
            {
                return NotFound();
            }

            return film;
        }

        // PUT: api/Film/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(int id, Film film)
        {
            if (id != film.FilmID)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
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

        // POST: api/Film
        [HttpPost]
        public async Task<ActionResult<Film>> PostFilm(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilm", new { id = film.FilmID }, film);
        }

        // DELETE: api/Film/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Film>> DeleteFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Films.Remove(film);
            await _context.SaveChangesAsync();

            return film;
        }

        // Upload a film poster
        [HttpPost("upload/{filmId}")]
        public async Task<IActionResult> UploadFilmPoster(int filmId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var film = await _context.Films.FindAsync(filmId);
            if (film == null)
            {
                return NotFound("Film not found.");
            }

            // Define the file path (save to wwwroot/uploads)
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", "films", file.FileName);

            // Create the directory if it doesn't exist
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Save the file to disk
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Update the film's Poster path in the database
            film.Poster = filePath.Replace(Directory.GetCurrentDirectory(), "").Replace("\\", "/");

            // Save the changes to the database
            _context.Films.Update(film);
            await _context.SaveChangesAsync();

            return Ok(new { filePath = film.Poster });
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.FilmID == id);
        }
    }
}
