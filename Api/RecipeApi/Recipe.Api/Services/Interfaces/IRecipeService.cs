using Recipe.Api.Models.Requests;
using Recipe.Common.Models;
using Recipe.Common.Models.Responses.Base;

namespace Recipe.Api.Services.Interfaces;

public interface IRecipeService
{
    Task<IResponse> GetRecipes();
    Task<IResponse> CreateRecipe(CreateRecipeRequest request);
    Task<IResponse> LikeRecipe(RecipeLikeModel model);
    Task<IResponse> UnlikeRecipe(RecipeLikeModel model);
}