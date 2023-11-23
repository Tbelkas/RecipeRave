using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Recipe.Api.Services;
using Recipe.Common;
using Recipe.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Recipe.Api.Services.Interfaces;
using Recipe.Common.Models;

namespace Recipe.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void SetupServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddAutoMapper(typeof(PersistenceStartup));
        serviceCollection.AddAutoMapper(typeof(Program));
        
        serviceCollection.AddIdentity<AppUserEntity, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedAccount = false;
            }
        )
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        
        serviceCollection.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });
        
        serviceCollection.AddLogging();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddControllers();
        
        serviceCollection.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wedding Planner API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });

        serviceCollection.RegisterServices();
    }

    private static void RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IAuthenticationService, AuthenticationService>();
        serviceCollection.AddTransient<IRecipeService, RecipeService>();
        serviceCollection.AddTransient<IMapper, Mapper>();
    }
}