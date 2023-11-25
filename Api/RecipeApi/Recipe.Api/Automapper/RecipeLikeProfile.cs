using AutoMapper;
using Recipe.Api.Models.Requests;
using Recipe.Common.Models;
using Recipe.Persistence.Entities;

namespace Recipe.Api.Automapper;

public class RecipeLikeProfile : Profile
{
    public RecipeLikeProfile()
    {
        CreateMap<CreateRecipeRequest, RecipeModel>();
    }
}