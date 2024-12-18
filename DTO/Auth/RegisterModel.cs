namespace Backend.DTO.Auth;
using System.ComponentModel.DataAnnotations;
public class RegisterModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
    public string Password { get; set; }
}
