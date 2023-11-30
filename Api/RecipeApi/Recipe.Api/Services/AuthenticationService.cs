using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Recipe.Api.Models.Requests;
using Recipe.Api.Models.Responses;
using Recipe.Api.Services.Interfaces;
using Recipe.Common.Models.Responses.Base;
using Recipe.Persistence.Entities;

namespace Recipe.Api.Services;

public class AuthenticationService(UserManager<AppUserEntity> userManager, IConfiguration configuration) : IAuthenticationService
{
    public async Task<IResponse> Register(RegisterUserRequest request)
    {
        var userByEmail = await userManager.FindByEmailAsync(request.Email);
        if (userByEmail is not null)
        {
            return new Response($"User with email {request.Email} already exists.");
        }
        
        var userByUsername = await userManager.FindByNameAsync(request.Username);
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

        var result = await userManager.CreateAsync(user, request.Password);

        return !result.Succeeded ? new Response(GetErrorsText(result.Errors)) : new Response();
    }

    public async Task<IResponse> Login(LoginUserRequest request)
    {
        var user = await userManager.FindByNameAsync(request.Username);
        if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
        {
            return new Response("Authentication failed");
        }
        var authClaims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Name, user.UserName!),
            new(ClaimTypes.Email, user.Email!),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        var claims = await userManager.GetRolesAsync(user);
        authClaims.AddRange(claims.Select(x => new Claim(ClaimTypes.Role, x)));
        var token = GetToken(authClaims);
        
        //todo better approach for token?
        return new Response<LoginResponse>(new LoginResponse{Token = new JwtSecurityTokenHandler().WriteToken(token)});
    }

    private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));

        var token = new JwtSecurityToken(
            issuer: configuration["JWT:ValidIssuer"],
            audience: configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddDays(365), // refresh token
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return token;
    }

    private static IEnumerable<string> GetErrorsText(IEnumerable<IdentityError> errors)
    {
        return errors.Select(error => error.Description);
    }
}