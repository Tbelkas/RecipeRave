using System.Net;
using Microsoft.AspNetCore.Mvc;
using Recipe.Api.Models;
using Recipe.Api.Models.Requests;
using Recipe.Api.Models.Responses;
using Recipe.Api.Models.Responses.Base;
using Recipe.Api.Services;
using Recipe.Api.Services.Interfaces;

namespace Recipe.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> RegisterUser(RegisterUserModel user)
    {
        var result = await authenticationService.Register(user);
        return StatusCode((int)result.StatusCode, result);
    }
    
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> LoginUser(LoginUserModel user)
    {
        var result = await authenticationService.Login(user);
        if (result is DataResponse<LoginResponse> dataResponse)
        {
            return StatusCode((int)result.StatusCode, dataResponse);
        }
        
        return StatusCode((int)result.StatusCode, result.ErrorMessages);
    }
}