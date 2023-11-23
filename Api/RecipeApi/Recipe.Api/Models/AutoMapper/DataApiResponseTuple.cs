using System.Net;
using Recipe.Api.Models.Responses.Base;

namespace Recipe.Api.Models.AutoMapper;

public class DataApiResponseTuple<T>
{
    public ApiDataResponse<T> Response { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}