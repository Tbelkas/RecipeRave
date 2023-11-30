// ReSharper disable SuggestBaseTypeForParameterInConstructor
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recipe.Api.Automapper.Models;
using Recipe.Api.Models.Constants;
using Recipe.Api.Models.Requests;
using Recipe.Common.Models;
using Recipe.Domain.Services.Interfaces;
using Recipe.Persistence.Entities;

namespace Recipe.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController(UserManager<AppUserEntity> userManager, IRecipeService recipeService, IMapper mapper) : ControllerBase
{
    
    // todo: lazy loading
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetRecipes()
    {
        var userId = userManager.GetUserId(User);
        var result = await recipeService.GetRecipes(userId!);
        var responseTuple = mapper.Map<ApiResponseTuple<List<LikesRecipeModel>>>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }    
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateRecipe(CreateRecipeRequest request)
    {
        var recipeModel = mapper.Map<RecipeModel>(request);
        var result = await recipeService.CreateRecipe(recipeModel);
        // todo : Map to StatusCode directly?
        var responseTuple = mapper.Map<ApiResponseTuple>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }    
    
    [HttpDelete]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> DeleteRecipe(DeleteRecipeRequest request)
    {
        var result = await recipeService.DeleteRecipe(request.RecipeId);
        var responseTuple = mapper.Map<ApiResponseTuple>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }    
    
    [Route("Like")]
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> LikeRecipe(LikeRecipeRequest request)
    {
        var userId = userManager.GetUserId(User);
        var likeModel = mapper.Map<RecipeLikeModel>((request.RecipeId, userId));
        var result = await recipeService.LikeRecipe(likeModel);
        var responseTuple = mapper.Map<ApiResponseTuple>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }
        
    [Route("Like")]
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> UnlikeRecipe(UnlikeRecipeRequest request)
    {
        var userId = userManager.GetUserId(User);
        var likeModel = mapper.Map<RecipeLikeModel>((request.RecipeId, userId));
        var result = await recipeService.UnlikeRecipe(likeModel);
        var responseTuple = mapper.Map<ApiResponseTuple>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }
    
}