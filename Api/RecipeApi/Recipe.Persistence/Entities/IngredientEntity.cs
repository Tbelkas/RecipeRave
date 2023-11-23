using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Common.Models.Enums;

namespace Recipe.Persistence.Entities;

[Table("Ingredients")]
public class IngredientEntity : BaseEntity
{
    public string Name { get; set; }
    [Column(TypeName = "decimal(8,4)")]
    public decimal IngredientAmount { get; set; }
    public MeasurementUnit MeasurementUnit { get; set; }
    public int RecipeId { get; set; }
    public RecipeEntity Recipe { get; set; }
}