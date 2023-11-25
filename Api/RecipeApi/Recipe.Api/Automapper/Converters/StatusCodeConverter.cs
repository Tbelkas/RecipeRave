using System.Net;
using AutoMapper;
using Recipe.Common.Models.Enums;

namespace Recipe.Api.Automapper.Converters;

public class StatusCodeConverter : IValueConverter<StatusCode, HttpStatusCode>
{

    public HttpStatusCode Convert(StatusCode source, ResolutionContext context)
    {
        return source switch
        {
            StatusCode.Ok => HttpStatusCode.OK,
            StatusCode.ArgumentError => HttpStatusCode.BadRequest,
            StatusCode.NotFound => HttpStatusCode.NotFound,
            _ => HttpStatusCode.InternalServerError
        };
    }
}