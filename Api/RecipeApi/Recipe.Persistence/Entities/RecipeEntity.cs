// ReSharper disable EntityFramework.ModelValidation.UnlimitedStringLength todo

using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Persistence.Entities;

[Table("Recipes")]
public class RecipeEntity : BaseEntity
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public List<IngredientEntity>? Ingredients { get; init; } 
    public List<AppUserEntity>? LikedUsers { get; init; }
    
    // todo : store url and keep link to cdn 
    public string? Base64Image { get; init; }
}