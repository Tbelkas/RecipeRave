using AutoMapper;
using Recipe.Api.Models.Requests;
using Recipe.Common.Models;

namespace Recipe.Api.Automapper;

// ReSharper disable once UnusedType.Global
public class RecipeLikeProfile : Profile
{
    public RecipeLikeProfile()
    {
        CreateMap<CreateRecipeRequest, RecipeModel>();
    }
}