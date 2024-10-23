using Microsoft.AspNetCore.Identity;

namespace Core.Infrastructure.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string CompanyName { get; set; }
    public required DateOnly DateOfBirth { get; set; }
}
