using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
{
    public interface ILangueRepository
    {
        Task<IEnumerable<Langue>> GetAllLanguesAsync();
        Task<Langue> GetLangueByIdAsync(int id);
        Task<Langue> AddLangueAsync(Langue langue);
        Task UpdateLangueAsync(Langue langue);
        Task DeleteLangueAsync(int id);
    }
}
