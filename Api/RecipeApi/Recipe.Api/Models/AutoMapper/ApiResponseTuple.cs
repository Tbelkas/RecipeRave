using System.Net;
using Recipe.Api.Models.Responses.Base;

namespace Recipe.Api.Models.AutoMapper;

public class ApiResponseTuple
{
    public ApiResponse Response { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}