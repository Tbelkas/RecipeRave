using AutoMapper;
using Recipe.Common.Models;
using Recipe.Persistence.Entities;

namespace Recipe.Api.Automapper;

public class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<RecipeEntity, RecipeEntity>().ReverseMap();
        CreateMap<IngredientModel, IngredientEntity>().ReverseMap();
    }
}