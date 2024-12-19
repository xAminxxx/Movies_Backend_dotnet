using Microsoft.EntityFrameworkCore;
using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class EditeurRepository : IEditeurRepository
    {
        private readonly ApplicationDbContext _context;

        public EditeurRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Editeur>> GetAllEditeursAsync()
        {
            return await _context.Editeurs.ToListAsync();
        }

        public async Task<Editeur> GetEditeurByIdAsync(int id)
        {
            return await _context.Editeurs
                .FirstOrDefaultAsync(e => e.EditeurID == id);
        }

        public async Task<Editeur> AddEditeurAsync(Editeur editeur)
        {
            _context.Editeurs.Add(editeur);
            await _context.SaveChangesAsync();
            return editeur;
        }

        public async Task UpdateEditeurAsync(Editeur editeur)
        {
            _context.Entry(editeur).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEditeurAsync(int id)
        {
            var editeur = await _context.Editeurs.FindAsync(id);
            if (editeur != null)
            {
                _context.Editeurs.Remove(editeur);
                await _context.SaveChangesAsync();
            }
        }
    }
}
