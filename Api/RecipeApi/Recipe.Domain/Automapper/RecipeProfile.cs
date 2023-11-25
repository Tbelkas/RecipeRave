using AutoMapper;
using Recipe.Common.Models;
using Recipe.Persistence.Entities;

namespace Recipe.Domain.Automapper;

public class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<RecipeEntity, RecipeModel>().ReverseMap();
        CreateMap<IngredientModel, IngredientEntity>().ReverseMap();
    }
}