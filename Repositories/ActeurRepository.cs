using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class ActeurRepository : IActeurRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ActeurRepository(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IEnumerable<Acteur>> GetAllActeursAsync()
        {
            return await _context.Acteurs.ToListAsync();
        }

        public async Task<Acteur> GetActeurByIdAsync(int id)
        {
            return await _context.Acteurs.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Acteur> AddActeurAsync(Acteur acteur)
        {
            _context.Acteurs.Add(acteur);
            await _context.SaveChangesAsync();
            return acteur;
        }

        public async Task UpdateActeurAsync(Acteur acteur)
        {
            _context.Entry(acteur).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteActeurAsync(int id)
        {
            var acteur = await _context.Acteurs.FindAsync(id);
            if (acteur != null)
            {
                _context.Acteurs.Remove(acteur);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> UploadProfilePictureAsync(int acteurId, IFormFile file)
        {
            var acteur = await _context.Acteurs.FindAsync(acteurId);
            if (acteur == null)
            {
                throw new FileNotFoundException("Acteur not found.");
            }

            // Ensure directory exists
            var uploadsDirectory = Path.Combine(_env.ContentRootPath, "uploads", "acteurs");
            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            // Generate unique file name to avoid collisions
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var fullFilePath = Path.Combine(uploadsDirectory, fileName);

            // Save the file
            using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Update the acteur's ProfilePicture path (relative to API root)
            acteur.ProfilePicture = $"/uploads/acteurs/{fileName}";
            acteur.UpdatedAt = DateTime.Now;

            _context.Entry(acteur).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return acteur.ProfilePicture;
        }
    }
}
