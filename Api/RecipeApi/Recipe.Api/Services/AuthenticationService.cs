﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Recipe.Api.Models.Requests;
using Recipe.Api.Models.Responses;
using Recipe.Api.Models.Responses.Base;
using Recipe.Api.Services.Interfaces;
using Recipe.Common.Models;
using Recipe.Common.Models.Responses.Base;
using Recipe.Persistence.Entities;

namespace Recipe.Api.Services;

public class AuthenticationService : IAuthenticationService
{
    private UserManager<AppUserEntity> _userManager { get; }
    private IConfiguration _configuration { get; }

    public AuthenticationService(UserManager<AppUserEntity> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
    
    public async Task<IResponse> Register(RegisterUserRequest request)
    {
        var userByEmail = await _userManager.FindByEmailAsync(request.Email);
        if (userByEmail is not null)
        {
            return new Response($"User with email {request.Email} already exists.");
        }
        
        var userByUsername = await _userManager.FindByNameAsync(request.Username);
        if (userByUsername is not null)
        {
            return new Response($"User username {request.Username} already exists.");
        }

        var user = new AppUserEntity
        {
            Email = request.Email,
            UserName = request.Username,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        return !result.Succeeded ? new Response(GetErrorsText(result.Errors)) : new Response();
    }

    public async Task<IResponse> Login(LoginUserRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.Username);
        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            return new Response($"Authentication failed");
        }

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = GetToken(authClaims);
        
        //todo better approach for token?
        return new Response<LoginResponse>(new LoginResponse{Token = new JwtSecurityTokenHandler().WriteToken(token)});
    }

    private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return token;
    }

    private IEnumerable<string> GetErrorsText(IEnumerable<IdentityError> errors)
    {
        return errors.Select(error => error.Description);
    }
}