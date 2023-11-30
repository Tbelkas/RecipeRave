// ReSharper disable UnusedMemberInSuper.Global
namespace Recipe.Api.Models.Responses.Base;

public interface IApiResponse
{
    List<string>? ErrorMessages { get; set; }
}
