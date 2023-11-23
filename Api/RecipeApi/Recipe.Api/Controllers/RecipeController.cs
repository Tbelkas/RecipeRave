using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Recipe.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    // todo: lazy loading
    [HttpGet]
    [Authorize]
    public string GetRecipes()
    {
        return "Hi";
    }
}