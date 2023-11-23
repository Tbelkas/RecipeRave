using System.Net;
using Recipe.Common.Models.Enums;

namespace Recipe.Common.Models.Responses.Base;

public interface IResponse
{
    List<string> ErrorMessages { get; set; }
    StatusCode StatusCode { get; set; }
}
