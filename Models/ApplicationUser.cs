using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    // Explicitly define Email
    public override string Email { get; set; }

    // Explicitly define UserName
    public override string UserName { get; set; }

    // Explicitly define PasswordHash (though it's managed by Identity)
    public override string PasswordHash { get; set; }
}
