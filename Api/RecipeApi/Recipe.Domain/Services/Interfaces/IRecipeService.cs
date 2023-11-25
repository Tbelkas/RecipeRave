using Recipe.Common.Models;
using Recipe.Common.Models.Responses.Base;

namespace Recipe.Domain.Services.Interfaces;

public interface IRecipeService
{
    Task<IResponse> GetRecipes();
    Task<IResponse> CreateRecipe(RecipeModel model);
    Task<IResponse> LikeRecipe(RecipeLikeModel model);
    Task<IResponse> UnlikeRecipe(RecipeLikeModel model);
}