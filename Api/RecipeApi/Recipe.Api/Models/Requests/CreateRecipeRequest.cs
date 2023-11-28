using Recipe.Common.Models;

namespace Recipe.Api.Models.Requests;

public class CreateRecipeRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IngredientModel> Ingredients { get; set; }
    public string Base64Image { get; set; } 
    // todo: Image
}