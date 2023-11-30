// ReSharper disable UnusedMember.Global
using Recipe.Common.Models;

namespace Recipe.Api.Models.Requests;

public class CreateRecipeRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required List<IngredientModel> Ingredients { get; set; }
    public required string Base64Image { get; set; } 
    // todo: Image
}