using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recipe.Api.Automapper.Models;
using Recipe.Api.Models.Requests;
using Recipe.Common.Models;
using Recipe.Domain.Services.Interfaces;
using Recipe.Persistence.Entities;

namespace Recipe.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUserEntity> _userManager;
    public RecipeController(UserManager<AppUserEntity> userManager, IRecipeService recipeService, IMapper mapper)
    {
        _recipeService = recipeService;
        _mapper = mapper;
        _userManager = userManager;
    }
    
    // todo: lazy loading
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetRecipes()
    {
        var result = await _recipeService.GetRecipes();
        var responseTuple = _mapper.Map<ApiResponseTuple<List<RecipeModel>>>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }    
    
    // todo: lazy loading
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateRecipe(CreateRecipeRequest request)
    {
        var recipeModel = _mapper.Map<RecipeModel>(request);
        var result = await _recipeService.CreateRecipe(recipeModel);
        // todo : Map to StatusCode directly?
        var responseTuple = _mapper.Map<ApiResponseTuple>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }    
    
    [Route("Like")]
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> LikeRecipe(LikeRecipeRequest request)
    {
        var userId = _userManager.GetUserId(User);
        var likeModel = _mapper.Map<RecipeLikeModel>((request.RecipeId, userId));
        var result = await _recipeService.LikeRecipe(likeModel);
        var responseTuple = _mapper.Map<ApiResponseTuple>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }
        
    [Route("Like")]
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> UnlikeRecipe(UnlikeRecipeRequest request)
    {
        var userId = _userManager.GetUserId(User);
        var likeModel = _mapper.Map<RecipeLikeModel>((request.RecipeId, userId));
        var result = await _recipeService.UnlikeRecipe(likeModel);
        var responseTuple = _mapper.Map<ApiResponseTuple>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }
    
}