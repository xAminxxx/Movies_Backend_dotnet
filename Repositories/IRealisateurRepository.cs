using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
{
    public interface IRealisateurRepository
    {
        Task<IEnumerable<Realisateurs>> GetAllRealisateursAsync();
        Task<Realisateurs> GetRealisateurByIdAsync(int id);
        Task<Realisateurs> AddRealisateurAsync(Realisateurs realisateur);
        Task UpdateRealisateurAsync(Realisateurs realisateur);
        Task DeleteRealisateurAsync(int id);
    }
}
