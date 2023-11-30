// ReSharper disable EntityFramework.ModelValidation.UnlimitedStringLength todo

using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Common.Models.Enums;

namespace Recipe.Persistence.Entities;

[Table("Ingredients")]
public class IngredientEntity : BaseEntity
{
    public required string Name { get; init; }
    [Column(TypeName = "decimal(8,4)")]
    public decimal IngredientAmount { get; init; }
    public MeasurementUnit MeasurementUnit { get; init; }
    public int RecipeId { get; init; }
    public RecipeEntity? Recipe { get; init; }
}