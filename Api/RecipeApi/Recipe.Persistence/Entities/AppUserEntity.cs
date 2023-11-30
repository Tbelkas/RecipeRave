// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedMember.Global 
// ReSharper disable EntityFramework.ModelValidation.UnlimitedStringLength todo
using Microsoft.AspNetCore.Identity;


namespace Recipe.Persistence.Entities;

public class AppUserEntity : IdentityUser
{
    public string? Name { get; init; }
    public List<RecipeEntity>? LikedRecipes { get; init; }
}