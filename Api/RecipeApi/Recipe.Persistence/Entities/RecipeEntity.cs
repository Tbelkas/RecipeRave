using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Persistence.Entities;

[Table("Recipes")]
public class RecipeEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<RecipeIngredientEntity> RecipeIngredients { get; set; } 
}