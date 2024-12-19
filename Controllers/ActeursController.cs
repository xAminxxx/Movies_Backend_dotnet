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
    public class ActeurController : ControllerBase
    {
        private readonly IActeurRepository _acteurRepository;

        public ActeurController(IActeurRepository acteurRepository)
        {
            _acteurRepository = acteurRepository;
        }

        // GET: api/Acteur
        [HttpGet]
        public async Task<IActionResult> GetAllActeurs()
        {
            var acteurs = await _acteurRepository.GetAllActeursAsync();
            return Ok(acteurs);
        }

        // GET: api/Acteur/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActeurById(int id)
        {
            var acteur = await _acteurRepository.GetActeurByIdAsync(id);
            if (acteur == null)
            {
                return NotFound(new { message = "Acteur introuvable." });
            }
            return Ok(acteur);
        }

        // POST: api/Acteur
        [HttpPost]
        public async Task<IActionResult> AddActeur([FromBody] Acteur acteur)
        {
            if (acteur == null)
            {
                return BadRequest(new { message = "Les données de l'acteur sont invalides." });
            }

            var addedActeur = await _acteurRepository.AddActeurAsync(acteur);
            return CreatedAtAction(nameof(GetActeurById), new { id = addedActeur.Id }, addedActeur);
        }

        // POST: api/Acteur/uploadProfilePicture/{id}
        [HttpPost("uploadProfilePicture/{id}")]
        public async Task<IActionResult> UploadProfilePicture(int id, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "Aucun fichier sélectionné." });
            }

            try
            {
                // Pass the IFormFile directly to the repository
                var uploadedFilePath = await _acteurRepository.UploadProfilePictureAsync(id, file);

                return Ok(new { message = "Photo de profil mise à jour avec succès.", profilePictureUrl = uploadedFilePath });
            }
            catch (FileNotFoundException)
            {
                return NotFound(new { message = "Acteur introuvable." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erreur interne du serveur: {ex.Message}" });
            }
        }

        // PUT: api/Acteur/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActeur(int id, [FromBody] Acteur acteur)
        {
            if (acteur == null || acteur.Id != id)
            {
                return BadRequest(new { message = "Les données de l'acteur sont invalides." });
            }

            try
            {
                await _acteurRepository.UpdateActeurAsync(acteur);
                return NoContent();
            }
            catch (FileNotFoundException)
            {
                return NotFound(new { message = "Acteur introuvable." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erreur interne du serveur: {ex.Message}" });
            }
        }

        // DELETE: api/Acteur/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActeur(int id)
        {
            try
            {
                await _acteurRepository.DeleteActeurAsync(id);
                return NoContent();
            }
            catch (FileNotFoundException)
            {
                return NotFound(new { message = "Acteur introuvable." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erreur interne du serveur: {ex.Message}" });
            }
        }
    }
}
