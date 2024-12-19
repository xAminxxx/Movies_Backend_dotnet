using Microsoft.EntityFrameworkCore;
using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class LangueRepository : ILangueRepository
    {
        private readonly ApplicationDbContext _context;

        public LangueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Langue>> GetAllLanguesAsync()
        {
            return await _context.Langues.ToListAsync();
        }

        public async Task<Langue> GetLangueByIdAsync(int id)
        {
            return await _context.Langues
                .FirstOrDefaultAsync(l => l.LangueID == id);
        }

        public async Task<Langue> AddLangueAsync(Langue langue)
        {
            _context.Langues.Add(langue);
            await _context.SaveChangesAsync();
            return langue;
        }

        public async Task UpdateLangueAsync(Langue langue)
        {
            _context.Entry(langue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLangueAsync(int id)
        {
            var langue = await _context.Langues.FindAsync(id);
            if (langue != null)
            {
                _context.Langues.Remove(langue);
                await _context.SaveChangesAsync();
            }
        }
    }
}
