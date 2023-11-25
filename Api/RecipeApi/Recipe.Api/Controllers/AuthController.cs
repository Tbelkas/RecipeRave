using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipe.Api.Automapper.Models;
using Recipe.Api.Models.Requests;
using Recipe.Api.Models.Responses;
using Recipe.Api.Models.Responses.Base;
using Recipe.Api.Services.Interfaces;

namespace Recipe.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController: ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public AuthController(IAuthenticationService authenticationService, IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
    }
    
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> RegisterUser(RegisterUserRequest user)
    {
        var result = await _authenticationService.Register(user);
        var responseTuple = _mapper.Map<ApiResponseTuple>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }
    
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> LoginUser(LoginUserRequest user)
    {
        var result = await _authenticationService.Login(user);
        var responseTuple = _mapper.Map<ApiResponseTuple<LoginResponse>>(result);
        return StatusCode((int)responseTuple.StatusCode, responseTuple.Response);
    }
}