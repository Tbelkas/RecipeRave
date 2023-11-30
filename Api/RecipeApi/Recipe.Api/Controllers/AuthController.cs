// ReSharper disable SuggestBaseTypeForParameterInConstructor
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipe.Api.Automapper.Models;
using Recipe.Api.Models.Requests;
using Recipe.Api.Models.Responses;
using Recipe.Api.Services.Interfaces;

namespace Recipe.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthenticationService authenticationService, IMapper mapper) : ControllerBase
{
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> RegisterUser(RegisterUserRequest user)
    {
        var result = await authenticationService.Register(user);
        var responseTuple = mapper.Map<ApiResponseTuple>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }
    
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> LoginUser(LoginUserRequest user)
    {
        var result = await authenticationService.Login(user);
        var responseTuple = mapper.Map<ApiResponseTuple<LoginResponse>>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }
}