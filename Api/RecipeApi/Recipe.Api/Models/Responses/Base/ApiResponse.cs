using System.Text.Json.Serialization;

namespace Recipe.Api.Models.Responses.Base;

public class ApiResponse<T> : ApiResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Data { get; set; }

    public ApiResponse()
    {
    }
    
    public ApiResponse(T? data)
    {
        Data = data;
    }
}
public class ApiResponse : IApiResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? ErrorMessages { get; set; }
    public ApiResponse()
    {
    }
    
    public ApiResponse(string error)
    {
        ErrorMessages = new List<string>{error};
    }
        
    public ApiResponse(IEnumerable<string> errors)
    {
        ErrorMessages = errors.ToList();
    }
}