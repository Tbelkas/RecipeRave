using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recipe.Common;
using Recipe.Common.Models;
using Recipe.Persistence.Entities;

namespace Recipe.Persistence;

public class AppDbContext  : IdentityDbContext<AppUser>
{
    private DbSet<IngredientEntity> Ingredients { get; set; }
    private DbSet<RecipeEntity> Recipes { get; set; }
    private DbSet<RecipeIngredientEntity> RecipeIngredients { get; set; }
    public AppDbContext()
    {
            
    }
        
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<AppUser>(entity => entity.ToTable("Users"));
        modelBuilder.Entity<IdentityRole>(entity => entity.ToTable("Roles"));
        modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.ToTable("UserRoles"));
        modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable("UserClaims"));
        modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable("UserLogins"));
        modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable("RoleClaims"));
        modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.ToTable("UserTokens"));

        modelBuilder.Entity<RecipeIngredientEntity>(entity =>
        {
            entity.HasKey(x => new { x.RecipeId, x.IngredientId });
        });
    }
}