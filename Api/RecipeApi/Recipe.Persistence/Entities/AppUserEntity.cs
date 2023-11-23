using Microsoft.AspNetCore.Identity;

namespace Recipe.Common.Models;

// todo http context user
public class AppUserEntity : IdentityUser
{
    public string? Name { get; set; }
}