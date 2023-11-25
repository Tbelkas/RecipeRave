using System.Net;
using Recipe.Common.Models.Enums;

namespace Recipe.Common.Models.Responses.Base;


public class Response<T> : Response
{
    public T? Data { get; set; }
    public Response(T? data)
    {
        Data = data;
        StatusCode = StatusCode.Ok;
    }
}

public class Response : IResponse
{
    public List<string>? ErrorMessages { get; set; }
    public StatusCode StatusCode { get; set; }
   
    public Response(StatusCode code = StatusCode.Ok)
    {
        StatusCode = code;
    }
    
    public Response(string error, StatusCode code = StatusCode.ArgumentError)
    {
        StatusCode = code;
        ErrorMessages = new List<string>{error};
    }
        
    public Response(IEnumerable<string> errors, StatusCode code = StatusCode.ArgumentError)
    {
        StatusCode = code;
        ErrorMessages = errors.ToList();
    }

}