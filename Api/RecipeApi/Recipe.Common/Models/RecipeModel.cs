namespace Recipe.Common.Models;

public class RecipeModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IngredientModel> Ingredients { get; set; }
    // todo: Image
}