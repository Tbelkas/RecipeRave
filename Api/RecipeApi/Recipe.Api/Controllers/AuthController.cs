using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipe.Api.Models.AutoMapper;
using Recipe.Api.Models.Requests;
using Recipe.Api.Models.Responses;
using Recipe.Api.Models.Responses.Base;
using Recipe.Api.Services.Interfaces;
using Recipe.Common.Models.Responses.Base;

namespace Recipe.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthenticationService authenticationService, IMapper _mapper) : ControllerBase
{
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> RegisterUser(RegisterUserRequest user)
    {
        var result = await authenticationService.Register(user);
        var responseTuple = _mapper.Map<ApiResponseTuple>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }
    
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> LoginUser(LoginUserRequest user)
    {
        var result = await authenticationService.Login(user);
        var responseTuple = _mapper.Map<DataApiResponseTuple<LoginResponse>>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }
}