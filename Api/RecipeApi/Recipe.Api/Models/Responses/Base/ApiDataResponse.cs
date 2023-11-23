namespace Recipe.Api.Models.Responses.Base;

public class ApiDataResponse<T> : ApiResponse
{
    public T Data { get; set; }

    public ApiDataResponse(T data)
    {
        Data = data;
    }
}