using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipe.Persistence.Repositories;
using Recipe.Persistence.Repositories.Interfaces;

namespace Recipe.Persistence;

public static class PersistenceStartup
{
    public static void Setup(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnectionString");
        services.AddMemoryCache();
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        RegisterRepositories(services);
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddTransient<IRecipeRepository, RecipeRepository>();
    }
}