using Backend.DTO.Auth;
using Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var message = await _authRepository.RegisterAsync(model);
                    return Ok(new { message });
                }
                catch (InvalidOperationException ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }

            return BadRequest("Invalid registration attempt");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var token = await _authRepository.LoginAsync(model);
                    return Ok(new { message = "Login successful", token });
                }
                catch (UnauthorizedAccessException)
                {
                    return Unauthorized("Invalid credentials");
                }
            }

            return BadRequest("Invalid login attempt");
        }

        [Authorize]
        [HttpGet("user-info")]
        public IActionResult GetUserInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            return Ok(new { userId });
        }
    }
}
