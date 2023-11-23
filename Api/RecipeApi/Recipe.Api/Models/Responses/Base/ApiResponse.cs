using System.Net;

namespace Recipe.Api.Models.Responses.Base;

public class ApiResponse : IApiResponse
{
    public List<string> ErrorMessages { get; set; } = [];
    public ApiResponse()
    {
    }
    
    public ApiResponse(string error)
    {
        ErrorMessages = [error];
    }
        
    public ApiResponse(IEnumerable<string> errors)
    {
        ErrorMessages = errors.ToList();
    }
    
}