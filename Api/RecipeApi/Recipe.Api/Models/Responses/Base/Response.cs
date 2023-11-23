using System.Net;

namespace Recipe.Api.Models.Responses.Base;

public class Response : IResponse
{
    public List<string> ErrorMessages { get; set; } = [];
    public HttpStatusCode StatusCode { get; set; }
    public Response(HttpStatusCode code = HttpStatusCode.OK)
    {
        StatusCode = code;
    }
    
    public Response(string error, HttpStatusCode code = HttpStatusCode.BadRequest)
    {
        StatusCode = code;
        ErrorMessages = [error];
    }
        
    public Response(IEnumerable<string> errors, HttpStatusCode code = HttpStatusCode.BadRequest)
    {
        StatusCode = code;
        ErrorMessages = errors.ToList();
    }
    
}