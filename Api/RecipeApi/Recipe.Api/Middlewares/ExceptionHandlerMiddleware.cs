using System.Net;
using System.Text.Json;
using Recipe.Api.Models.Responses.Base;

namespace Recipe.Api.Middlewares;

public class ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            // todo: set globally in app
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            
            var response = context.Response;
            var exceptionMessage = exception.Message;
            logger.LogError(
                "Error Message: {exceptionMessage}, Time of occurrence {time}",
                exceptionMessage, DateTime.UtcNow);

            context.Response.Headers.Add("Content-Type", "application/json");
            var result = JsonSerializer.Serialize(new ApiResponse("Something wrong happened"), jsonOptions);
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await response.WriteAsync(result);
        }
    }
}