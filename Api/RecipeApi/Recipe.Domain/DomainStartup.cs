using Microsoft.Extensions.DependencyInjection;
using Recipe.Domain.Services;
using Recipe.Domain.Services.Interfaces;

namespace Recipe.Domain;

public class DomainStartup
{
    public static void Setup(IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(cfg => cfg.AllowNullCollections = true, typeof(DomainStartup));
        RegisterServices(serviceCollection);
    }

    private static void RegisterServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IRecipeService, RecipeService>();
    }
}