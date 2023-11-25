using Microsoft.AspNetCore.Identity;

namespace Recipe.Persistence.Entities;

// todo http context user
public class AppUserEntity : IdentityUser
{
    public string? Name { get; set; }
    
    public List<RecipeEntity> LikedRecipes { get; set; }
}