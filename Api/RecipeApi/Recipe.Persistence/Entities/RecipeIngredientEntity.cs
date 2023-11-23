using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Persistence.Entities.Enums;

namespace Recipe.Persistence.Entities;

[Table("RecipesIngredients")]
public class RecipeIngredientEntity : BaseDateEntity
{
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public RecipeEntity Recipe { get; set; } = null!;
    public IngredientEntity Ingredient { get; set; } = null!;
    [Column(TypeName = "decimal(8,4)")]
    public decimal IngredientAmount { get; set; }
    public MeasurementUnit MeasurementUnit { get; set; }
}