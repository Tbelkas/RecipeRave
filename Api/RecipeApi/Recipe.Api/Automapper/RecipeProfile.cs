﻿using AutoMapper;
using Recipe.Api.Models.Requests;
using Recipe.Common.Models;

namespace Recipe.Api.Automapper;

public class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<CreateRecipeRequest, RecipeModel>();
    }
}