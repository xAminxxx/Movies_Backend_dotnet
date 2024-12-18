using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ActeurController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ActeurController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // POST: api/Acteur/uploadProfilePicture/{id}
        [HttpPost("uploadProfilePicture/{id}")]
        public async Task<IActionResult> UploadProfilePicture(int id, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "Aucun fichier sélectionné." });
            }

            var acteur = await _context.Acteurs.FindAsync(id);
            if (acteur == null)
            {
                return NotFound(new { message = "Acteur introuvable." });
            }

            // Ensure directory exists
            var uploadsDirectory = Path.Combine(_env.ContentRootPath, "uploads", "acteurs"); // Using ContentRootPath to avoid WebRootPath
            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            // Generate unique file name to avoid collisions
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(uploadsDirectory, fileName);

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Update the acteur's ProfilePicture path (relative to API root)
            acteur.ProfilePicture = $"/uploads/acteurs/{fileName}";
            acteur.UpdatedAt = DateTime.Now;

            _context.Entry(acteur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActeurExists(id))
                {
                    return NotFound(new { message = "Acteur introuvable." });
                }
                throw;
            }

            return Ok(new { message = "Photo de profil mise à jour avec succès.", profilePictureUrl = acteur.ProfilePicture });
        }

        // Other endpoints remain unchanged

        private bool ActeurExists(int id)
        {
            return _context.Acteurs.Any(e => e.Id == id);
        }
    }
}
