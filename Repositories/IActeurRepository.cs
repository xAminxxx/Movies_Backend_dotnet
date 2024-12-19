using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Http;

namespace Backend.Repositories
{
    public interface IActeurRepository
    {
        Task<IEnumerable<Acteur>> GetAllActeursAsync();
        Task<Acteur> GetActeurByIdAsync(int id);
        Task<Acteur> AddActeurAsync(Acteur acteur);
        Task UpdateActeurAsync(Acteur acteur);
        Task DeleteActeurAsync(int id);
        Task<string> UploadProfilePictureAsync(int acteurId, IFormFile file);  // Updated method signature
    }
}
