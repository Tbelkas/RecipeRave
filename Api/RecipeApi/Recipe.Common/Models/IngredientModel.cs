using Recipe.Common.Models.Enums;

namespace Recipe.Common.Models;

public class IngredientModel
{
    public string Name { get; set; }
    public decimal IngredientAmount { get; set; }
    public MeasurementUnit MeasurementUnit { get; set; }
}