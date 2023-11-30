using System.Net;
using Recipe.Api.Models.Responses.Base;

namespace Recipe.Api.Automapper.Models;

public class ApiResponseTuple<T>
{
    public required ApiResponse<T> Response { get; init; }
    public HttpStatusCode StatusCode { get; init; }
}

public class ApiResponseTuple
{
    public required ApiResponse Response { get; init; }
    public HttpStatusCode StatusCode { get; init; }
}