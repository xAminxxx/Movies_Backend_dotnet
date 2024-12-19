using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Http;

namespace Backend.Repositories
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Film>> GetAllFilmsAsync();
        Task<Film> GetFilmByIdAsync(int id);
        Task<Film> AddFilmAsync(Film film);
        Task UpdateFilmAsync(Film film);
        Task DeleteFilmAsync(int id);
        Task<string> UploadFilmPosterAsync(int filmId, IFormFile file); 
    }
}
