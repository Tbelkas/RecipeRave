using System.Net;

namespace Recipe.Api.Models.Responses.Base;

public interface IResponse
{
    List<string> ErrorMessages { get; set; }
    HttpStatusCode StatusCode { get; set; }
}
