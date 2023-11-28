using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Recipe.Common.Models;
using Recipe.Common.Models.Responses.Base;
using Recipe.Domain.Services.Interfaces;
using Recipe.Persistence.Entities;
using Recipe.Persistence.Repositories.Interfaces;

namespace Recipe.Domain.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMapper _mapper;

    public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
    {
        _recipeRepository = recipeRepository;
        _mapper = mapper;
    }

    public async Task<IResponse> GetRecipes(string userId)
    {
        var recipeEntities = await _recipeRepository.GetAllRecipes();
        var recipes = _mapper.Map<List<LikesRecipeModel>>(recipeEntities.Select(x => (x, userId)));
        return new Response<List<LikesRecipeModel>>(recipes);
    }

    public async Task<IResponse> CreateRecipe(RecipeModel model)
    {
        var recipeEntity = _mapper.Map<RecipeEntity>(model);
        await _recipeRepository.InsertRecipe(recipeEntity);

        return new Response();
    }
    
    public async Task<IResponse> DeleteRecipe(int recipeId)
    {
        var recipeEntity = new RecipeEntity { Id = recipeId };
        await _recipeRepository.DeleteRecipe(recipeEntity);

        return new Response();
    }
    
    public async Task<IResponse> LikeRecipe(RecipeLikeModel model)
    {
        try
        {
            var likeEntity = _mapper.Map<RecipeLikeEntity>(model);
            await _recipeRepository.LikeRecipe(likeEntity);
            return new Response();
        }
        catch (DbUpdateException ex)
        {
            // todo log
            // todo silent failure?
            // todo separate error message depending on why it can't be updated.
            return new Response("Recipe doesn't exist or it's already liked");
        }
    }

    public async Task<IResponse> UnlikeRecipe(RecipeLikeModel model)
    {
        try
        {
            var likeEntity = _mapper.Map<RecipeLikeEntity>(model);
            await _recipeRepository.UnlikeRecipe(likeEntity);
            return new Response();
        }
        catch (DbUpdateException ex)
        {
            // todo log
            // todo silent failure?
            // todo separate error message depending on why it can't be updated.
            return new Response("Recipe doesn't exist or it's not liked");
        }
      
    }

}