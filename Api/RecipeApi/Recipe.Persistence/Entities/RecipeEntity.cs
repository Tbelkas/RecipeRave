using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Common.Models;

namespace Recipe.Persistence.Entities;

[Table("Recipes")]
public class RecipeEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IngredientEntity> Ingredients { get; set; } 
    public List<AppUserEntity> LikedUsers { get; set; }
}