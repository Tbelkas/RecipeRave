using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

    }
}