using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IFilmRepository _filmRepository;

        public FilmController(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        // GET: api/Film
        [HttpGet]
        public async Task<IActionResult> GetAllFilms()
        {
            var films = await _filmRepository.GetAllFilmsAsync();
            return Ok(films);
        }

        // GET: api/Film/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmById(int id)
        {
            var film = await _filmRepository.GetFilmByIdAsync(id);
            if (film == null)
            {
                return NotFound(new { message = $"Film with ID {id} not found." });
            }
            return Ok(film);
        }

        // POST: api/Film
        [HttpPost]
        public async Task<IActionResult> AddFilm([FromBody] Film film)
        {
            if (film == null)
            {
                return BadRequest(new { message = "Film data is invalid." });
            }

            try
            {
                var addedFilm = await _filmRepository.AddFilmAsync(film);
                return CreatedAtAction(nameof(GetFilmById), new { id = addedFilm.FilmID }, addedFilm);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
            }
        }

        // POST: api/Film/uploadPoster/{id}
        [HttpPost("uploadPoster/{id}")]
        public async Task<IActionResult> UploadFilmPoster(int id, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "No file selected." });
            }

            try
            {
                // Pass the IFormFile directly to the repository
                var uploadedFilePath = await _filmRepository.UploadFilmPosterAsync(id, file);

                return Ok(new { message = "Film poster updated successfully.", posterUrl = uploadedFilePath });
            }
            catch (FileNotFoundException)
            {
                return NotFound(new { message = "Film not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
            }
        }

        // PUT: api/Film/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFilm(int id, [FromBody] Film film)
        {
            if (film == null || film.FilmID != id)
            {
                return BadRequest(new { message = "Film data is invalid." });
            }

            try
            {
                await _filmRepository.UpdateFilmAsync(film);
                return NoContent();
            }
            catch (FileNotFoundException)
            {
                return NotFound(new { message = "Film not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
            }
        }

        // DELETE: api/Film/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            try
            {
                var film = await _filmRepository.GetFilmByIdAsync(id);
                if (film == null)
                {
                    return NotFound(new { message = $"Film with ID {id} not found." });
                }

                await _filmRepository.DeleteFilmAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
            }
        }
    }
}
