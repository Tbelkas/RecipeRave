using Recipe.Api.Models.Requests;
using Recipe.Api.Models.Responses.Base;
using Recipe.Common.Models.Responses.Base;

namespace Recipe.Api.Services.Interfaces;

public interface IAuthenticationService
{
    Task<IResponse> Register(RegisterUserRequest request);
    Task<IResponse> Login(LoginUserRequest request);
}