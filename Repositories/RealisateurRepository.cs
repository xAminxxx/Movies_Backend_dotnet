using Microsoft.EntityFrameworkCore;
using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class RealisateurRepository : IRealisateurRepository
    {
        private readonly ApplicationDbContext _context;

        public RealisateurRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Realisateurs>> GetAllRealisateursAsync()
        {
            return await _context.Realisateurs.ToListAsync();
        }

        public async Task<Realisateurs> GetRealisateurByIdAsync(int id)
        {
            return await _context.Realisateurs
                .FirstOrDefaultAsync(r => r.RealisateursID == id);
        }

        public async Task<Realisateurs> AddRealisateurAsync(Realisateurs realisateur)
        {
            _context.Realisateurs.Add(realisateur);
            await _context.SaveChangesAsync();
            return realisateur;
        }

        public async Task UpdateRealisateurAsync(Realisateurs realisateur)
        {
            _context.Entry(realisateur).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRealisateurAsync(int id)
        {
            var realisateur = await _context.Realisateurs.FindAsync(id);
            if (realisateur != null)
            {
                _context.Realisateurs.Remove(realisateur);
                await _context.SaveChangesAsync();
            }
        }
    }
}
