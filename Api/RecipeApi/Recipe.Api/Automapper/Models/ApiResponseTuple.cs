using System.Net;
using Recipe.Api.Models.Responses.Base;

namespace Recipe.Api.Automapper.Models;

public class ApiResponseTuple<T>
{
    public ApiResponse<T> Response { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}

public class ApiResponseTuple
{
    public ApiResponse Response { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}