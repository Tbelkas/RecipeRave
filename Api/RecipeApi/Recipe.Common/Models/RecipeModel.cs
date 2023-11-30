namespace Recipe.Common.Models;

public class RecipeModel
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required List<IngredientModel> Ingredients { get; init; }
    public string? Base64Image { get; init; } 
}