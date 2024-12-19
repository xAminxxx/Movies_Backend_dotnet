using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
{
    public interface IEditeurRepository
    {
        Task<IEnumerable<Editeur>> GetAllEditeursAsync();
        Task<Editeur> GetEditeurByIdAsync(int id);
        Task<Editeur> AddEditeurAsync(Editeur editeur);
        Task UpdateEditeurAsync(Editeur editeur);
        Task DeleteEditeurAsync(int id);
    }
}
