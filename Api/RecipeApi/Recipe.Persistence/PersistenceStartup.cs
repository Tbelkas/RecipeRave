using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipe.Persistence.Repositories;
using Recipe.Persistence.Repositories.Interfaces;

namespace Recipe.Persistence;

public static class PersistenceStartup
{
    public static void Setup(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnectionString");
        
        serviceCollection.AddAutoMapper(cfg => cfg.AllowNullCollections = true, typeof(PersistenceStartup));
        // todo: add memory caches
        serviceCollection.AddMemoryCache();
        serviceCollection.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        
        RegisterRepositories(serviceCollection);
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddTransient<IRecipeRepository, RecipeRepository>();
    }
}