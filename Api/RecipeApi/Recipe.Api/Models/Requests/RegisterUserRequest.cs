// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Recipe.Api.Models.Requests;

public class RegisterUserRequest
{
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}