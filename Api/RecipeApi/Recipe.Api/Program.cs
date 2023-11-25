using Recipe.Api.Extensions;
using Recipe.Api.Middlewares;
using Recipe.Domain;
using Recipe.Persistence;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

PersistenceStartup.Setup(services, configuration);
DomainStartup.Setup(services);
services.SetupServices(configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}


app.Run();
