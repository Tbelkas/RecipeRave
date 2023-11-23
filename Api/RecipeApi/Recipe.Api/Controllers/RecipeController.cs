using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recipe.Api.Models.AutoMapper;
using Recipe.Api.Models.Requests;
using Recipe.Api.Models.Responses.Base;
using Recipe.Api.Services.Interfaces;
using Recipe.Common.Models;

namespace Recipe.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUserEntity> _userManager;
    public RecipeController(UserManager<AppUserEntity> userManager,IRecipeService recipeService, IMapper mapper)
    {
        _recipeService = recipeService;
        _mapper = mapper;
        _userManager = userManager;
    }
    
    // todo: lazy loading
    [HttpGet]
    // [Authorize]
    public async Task<IActionResult> GetRecipes()
    {
        var result = await _recipeService.GetRecipes();
        var responseTuple = _mapper.Map<DataApiResponseTuple<List<RecipeModel>>>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }    
    
    // todo: lazy loading
    [HttpPost]
    // [Authorize]
    public async Task<IActionResult> CreateRecipe(CreateRecipeRequest request)
    {
        var result = await _recipeService.CreateRecipe(request);
        // todo : Map to StatusCode directly?
        var responseTuple = _mapper.Map<ApiResponseTuple>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }    
    
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> LikeRecipe(LikeRecipeRequest request)
    {
        var userId = _userManager.GetUserId(User);
        var likeModel = _mapper.Map<RecipeLikeModel>((request, userId));
        var result = await _recipeService.LikeRecipe(likeModel);
        var responseTuple = _mapper.Map<ApiResponseTuple>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }
        
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> UnlikeRecipe(LikeRecipeRequest request)
    {
        var userId = _userManager.GetUserId(User);
        var likeModel = _mapper.Map<RecipeLikeModel>((request, userId));
        var result = await _recipeService.UnlikeRecipe(likeModel);
        var responseTuple = _mapper.Map<ApiResponseTuple>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }
    
}