using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FilmRepository(ApplicationDbContext context,IWebHostEnvironment env)
        {
            _context = context;
             _env = env;
        }

        public async Task<IEnumerable<Film>> GetAllFilmsAsync()
        {
            return await _context.Films
                .Include(f => f.Categories)
                .Include(f => f.ActeurP)
                .Include(f => f.Editeur)
                .Include(f => f.Langues)
                .Include(f => f.Realisateur)
                .ToListAsync();
        }

        public async Task<Film> GetFilmByIdAsync(int id)
        {
            return await _context.Films
                .Include(f => f.Categories)
                .Include(f => f.ActeurP)
                .Include(f => f.Editeur)
                .Include(f => f.Langues)
                .Include(f => f.Realisateur)
                .FirstOrDefaultAsync(f => f.FilmID == id);
        }

        public async Task<Film> AddFilmAsync(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();
            return film;
        }

        public async Task UpdateFilmAsync(Film film)
        {
            _context.Entry(film).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFilmAsync(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film != null)
            {
                _context.Films.Remove(film);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> UploadFilmPosterAsync(int filmId, IFormFile file)
        {
            var film = await _context.Films.FindAsync(filmId);
            if (film == null)
            {
                throw new FileNotFoundException("Film not found.");
            }

            if (file != null && file.Length > 0)
            {
                var uploadsDirectory = Path.Combine(_env.ContentRootPath, "uploads", "films");
                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }
                var fileExtension = Path.GetExtension(file.FileName);
                var fileName = $"{Guid.NewGuid()}{fileExtension}";
                var fullFilePath = Path.Combine(uploadsDirectory, fileName);

                using (var stream = new FileStream(fullFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Update the film's poster field
            film.Poster = $"/uploads/films/{fileName}";
            film.UpdatedAt = DateTime.Now;

            _context.Entry(film).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return film.Poster;
            }

            throw new Exception("Invalid file.");
        }
    }
}
