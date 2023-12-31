﻿using AutoMapper;
using Recipe.Common.Models;
using Recipe.Persistence.Entities;

namespace Recipe.Domain.Automapper;
// ReSharper disable once UnusedType.Global
public class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<RecipeEntity, RecipeModel>().IncludeAllDerived().ReverseMap();
        // todo: fix mapping
        CreateMap<(RecipeEntity recipe, string userId), LikesRecipeModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.recipe.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.recipe.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.recipe.Description))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.recipe.Ingredients))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.recipe.CreatedBy))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.recipe.CreatedDate))
            .ForMember(dest => dest.Base64Image, opt => opt.MapFrom(src => src.recipe.Base64Image))
            .ForMember(dest => dest.LikeCount, opt => 
                opt.MapFrom(src => src.recipe.LikedUsers != null ? src.recipe.LikedUsers.Count : 0))
            .ForMember(dest => dest.HasUserLiked, opt => 
                opt.MapFrom(src => src.recipe.LikedUsers != null && src.recipe.LikedUsers.Select(x => x.Id).Contains(src.userId)));
        
        CreateMap<IngredientModel, IngredientEntity>().ReverseMap();
    }
}