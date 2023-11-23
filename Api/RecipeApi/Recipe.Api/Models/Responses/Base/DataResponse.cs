namespace Recipe.Api.Models.Responses.Base;

public class DataResponse<T> : Response
{
    public T Data { get; set; }

    public DataResponse(T data)
    {
        Data = data;
    }
}