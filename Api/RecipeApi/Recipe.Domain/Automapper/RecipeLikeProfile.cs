using AutoMapper;
using Recipe.Common.Models;
using Recipe.Persistence.Entities;

namespace Recipe.Domain.Automapper;

// ReSharper disable once UnusedType.Global
public class RecipeLikeProfile : Profile
{
    public RecipeLikeProfile()
    {
        CreateMap<(int recipeId, string userId), RecipeLikeModel>()
            .ForCtorParam(nameof(RecipeLikeModel.RecipeId), opt => opt.MapFrom(src => src.recipeId))
            .ForCtorParam(nameof(RecipeLikeModel.UserId), opt => opt.MapFrom(src => src.userId));

        CreateMap<RecipeLikeModel, RecipeLikeEntity>().ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.UserId));
    }
}