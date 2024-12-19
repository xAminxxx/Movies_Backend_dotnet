using Backend.DTO.Auth;

namespace Backend.Repositories
{
    public interface IAuthRepository
    {
        Task<string> RegisterAsync(RegisterModel model);
        Task<string> LoginAsync(LoginModel model);
        Task<string> GenerateJwtTokenAsync(ApplicationUser user); 
    }
}
