// ReSharper disable once SuggestBaseTypeForParameterInConstructor
// ReSharper disable SuggestBaseTypeForParameterInConstructor

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Recipe.Common.Models;
using Recipe.Common.Models.Responses.Base;
using Recipe.Domain.Services.Interfaces;
using Recipe.Persistence.Entities;
using Recipe.Persistence.Repositories.Interfaces;

namespace Recipe.Domain.Services;

public class RecipeService(IRecipeRepository recipeRepository, IMapper mapper, ILogger<RecipeService> logger) : IRecipeService
{
    public async Task<IResponse> GetRecipes(string userId)
    {
        var recipeEntities = await recipeRepository.GetAllRecipes();
        var recipes = mapper.Map<List<LikesRecipeModel>>(recipeEntities.Select(x => (x, userId)));
        return new Response<List<LikesRecipeModel>>(recipes);
    }

    public async Task<IResponse> CreateRecipe(RecipeModel model)
    {
        var recipeEntity = mapper.Map<RecipeEntity>(model);
        await recipeRepository.InsertRecipe(recipeEntity);

        return new Response();
    }
    
    public async Task<IResponse> DeleteRecipe(int recipeId)
    {
        await recipeRepository.DeleteRecipe(recipeId);
        return new Response();
    }
    
    public async Task<IResponse> LikeRecipe(RecipeLikeModel model)
    {
        try
        {
            var likeEntity = mapper.Map<RecipeLikeEntity>(model);
            await recipeRepository.LikeRecipe(likeEntity);
            return new Response();
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex, "LikeRecipe failed");
            // todo separate error message depending on why it can't be updated.
            return new Response("Recipe doesn't exist or it's already liked");
        }
    }

    public async Task<IResponse> UnlikeRecipe(RecipeLikeModel model)
    {
        try
        {
            var likeEntity = mapper.Map<RecipeLikeEntity>(model);
            await recipeRepository.UnlikeRecipe(likeEntity);
            return new Response();
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex, "UnlikeRecipe failed");
            // todo separate error message depending on why it can't be updated.
            return new Response("Recipe doesn't exist or it's not liked");
        }
      
    }

}