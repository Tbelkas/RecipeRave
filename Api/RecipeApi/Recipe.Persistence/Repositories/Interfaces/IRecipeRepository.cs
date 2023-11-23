using Recipe.Persistence.Entities;

namespace Recipe.Persistence.Repositories.Interfaces;

public interface IRecipeRepository
{
    Task<List<RecipeEntity>> GetAllRecipes();
    Task InsertRecipe(RecipeEntity entity);
    Task LikeRecipe(RecipeLikeEntity entity);
    Task UnlikeRecipe(RecipeLikeEntity entity);
}