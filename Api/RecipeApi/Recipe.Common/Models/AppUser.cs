using Microsoft.AspNetCore.Identity;

namespace Recipe.Common.Models;

public class AppUser : IdentityUser
{
    public string? Name { get; set; }
}