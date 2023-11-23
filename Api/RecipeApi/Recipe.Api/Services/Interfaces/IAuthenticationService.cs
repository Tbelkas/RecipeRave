using Recipe.Api.Models.Requests;
using Recipe.Api.Models.Responses.Base;

namespace Recipe.Api.Services.Interfaces;

public interface IAuthenticationService
{
    Task<IResponse> Register(RegisterUserModel model);
    Task<IResponse> Login(LoginUserModel request);

}