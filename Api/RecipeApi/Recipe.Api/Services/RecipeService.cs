using AutoMapper;
using Recipe.Api.Models.Requests;
using Recipe.Api.Services.Interfaces;
using Recipe.Common.Models;
using Recipe.Common.Models.Enums;
using Recipe.Persistence.Entities;
using Recipe.Persistence.Repositories.Interfaces;
using Recipe.Common.Models.Responses.Base;

namespace Recipe.Api.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMapper _mapper;

    public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
    {
        _recipeRepository = recipeRepository;
        _mapper = mapper;
    }

    public async Task<IResponse> GetRecipes()
    {
        // todo: don't expose entities
        var recipeEntities = await _recipeRepository.GetAllRecipes();
        var recipes = _mapper.Map<List<RecipeModel>>(recipeEntities);
        return new DataResponse<List<RecipeModel>>(recipes);
    }

    public async Task<IResponse> CreateRecipe(CreateRecipeRequest request)
    {
        var recipeModel = _mapper.Map<RecipeModel>(request);
        recipeModel = new RecipeModel
        {
            Name = "Nom soup",
            Description = "You first chop Nom1, then dice Nom2 and put it in the salted water pot",
            Ingredients =
            [
                new IngredientModel
                {
                    Name = "Nom1",
                    IngredientAmount = 200,
                    MeasurementUnit = MeasurementUnit.Gram
                },

                new IngredientModel
                {
                    Name = "Nom2",
                    IngredientAmount = 200,
                    MeasurementUnit = MeasurementUnit.Milliliter
                }
            ]
        };

        var recipeEntity = _mapper.Map<RecipeEntity>(request);
        await _recipeRepository.InsertRecipe(recipeEntity);

        return new Response();
    }
    
    public async Task<IResponse> LikeRecipe(RecipeLikeModel model)
    {
        var likeEntity = _mapper.Map<RecipeLikeEntity>(model);
        await _recipeRepository.LikeRecipe(likeEntity);
        return new Response();
    }

    public async Task<IResponse> UnlikeRecipe(RecipeLikeModel model)
    {
        var likeEntity = _mapper.Map<RecipeLikeEntity>(model);
        await _recipeRepository.UnlikeRecipe(likeEntity);
        return new Response();
    }

}