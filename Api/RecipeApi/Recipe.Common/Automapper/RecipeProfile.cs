using AutoMapper;
using Recipe.Api.Models.Requests;
using Recipe.Common.Models;
using Recipe.Persistence.Entities;

namespace Recipe.Api.Automapper;

public class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<CreateRecipeRequest, RecipeEntity>();
        CreateMap<RecipeEntity, RecipeModel>();
        CreateMap<IngredientModel, IngredientEntity>().ReverseMap();
    }
}