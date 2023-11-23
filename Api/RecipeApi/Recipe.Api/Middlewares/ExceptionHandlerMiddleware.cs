using System.Net;
using System.Text.Json;
using Recipe.Api.Models;
using Recipe.Api.Models.Responses.Base;

namespace Recipe.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var response = context.Response;
            var exceptionMessage = exception.Message;
            _logger.LogError(
                "Error Message: {exceptionMessage}, Time of occurrence {time}",
                exceptionMessage, DateTime.UtcNow);

            context.Response.Headers.Add("Content-Type", "application/json");
            var result = JsonSerializer.Serialize(new Response("Something wrong happened"));
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await response.WriteAsync(result);
        }
    }
}