using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Recipe.Api.Models;
using Recipe.Api.Models.Requests;
using Recipe.Api.Models.Responses;
using Recipe.Api.Models.Responses.Base;
using Recipe.Api.Services.Interfaces;
using Recipe.Common;
using Recipe.Common.Models;

namespace Recipe.Api.Services;

public class AuthenticationService(UserManager<AppUser> userManager, IConfiguration configuration)
    : IAuthenticationService
{
    public async Task<IResponse> Register(RegisterUserModel model)
    {
        var userByEmail = await userManager.FindByEmailAsync(model.Email);
        var userByUsername = await userManager.FindByNameAsync(model.Username);
        if (userByEmail is not null || userByUsername is not null)
        {
            return new Response($"User with email {model.Email} or username {model.Username} already exists.");
        }

        var user = new AppUser
        {
            Email = model.Email,
            UserName = model.Username,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await userManager.CreateAsync(user, model.Password);

        return !result.Succeeded ? new Response(GetErrorsText(result.Errors)) : new Response();
    }

    public async Task<IResponse> Login(LoginUserModel request)
    {
        var user = await userManager.FindByNameAsync(request.Username);
        if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
        {
            return new Response($"Authentication failed");
        }

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = GetToken(authClaims);
        
        //todo better approach for token?
        return new DataResponse<LoginResponse>(new LoginResponse{Token = new JwtSecurityTokenHandler().WriteToken(token)});
    }

    private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: configuration["JWT:ValidIssuer"],
            audience: configuration["JWT:ValidAudience"],
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