using Recipe.Common.Models;
using Recipe.Common.Models.Responses.Base;

namespace Recipe.Domain.Services.Interfaces;

public interface IRecipeService
{
    // todo: to model
    Task<IResponse> GetRecipes(string userId);
    Task<IResponse> CreateRecipe(RecipeModel model);
    Task<IResponse> DeleteRecipe(int recipeId);
    Task<IResponse> LikeRecipe(RecipeLikeModel model);
    Task<IResponse> UnlikeRecipe(RecipeLikeModel model);
}