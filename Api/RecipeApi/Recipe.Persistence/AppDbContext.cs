using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recipe.Persistence.Entities;

namespace Recipe.Persistence;

public class AppDbContext  : IdentityDbContext<AppUserEntity>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public DbSet<IngredientEntity> Ingredients { get; set; }
    public DbSet<RecipeEntity> Recipes { get; set; }
    public DbSet<RecipeLikeEntity> RecipeLikes { get; set; }
    public AppDbContext()
    {
            
    }
        
    public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
       
        modelBuilder.Entity<RecipeLikeEntity>(entity => entity.HasKey(x => new { x.RecipeId, x.AppUserId }));
        modelBuilder.Entity<AppUserEntity>(entity => entity.ToTable("Auth_AppUsers"));
        modelBuilder.Entity<IdentityRole>(entity => entity.ToTable("Auth_Roles"));
        modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.ToTable("Auth_UserRoles"));
        modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable("Auth_UserClaims"));
        modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable("Auth_UserLogins"));
        modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable("Auth_RoleClaims"));
        modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.ToTable("Auth_UserTokens"));
        
        modelBuilder.Entity<RecipeEntity>()
            .HasMany(e => e.LikedUsers)
            .WithMany(e => e.LikedRecipes)
            .UsingEntity<RecipeLikeEntity>(
                r => r.HasOne<AppUserEntity>().WithMany().HasForeignKey(e => e.AppUserId),
                l => l.HasOne<RecipeEntity>().WithMany().HasForeignKey(e => e.RecipeId)
            );
    }
    
    public override int SaveChanges()
    {
        ApplyAuditInformation();
        return base.SaveChanges();
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        ApplyAuditInformation();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditInformation()
    {
        var entities = ChangeTracker.Entries().Where(x => x is { Entity: BaseAuditEntity, State: EntityState.Added or EntityState.Modified });
        var userName = _httpContextAccessor.HttpContext?.User.Identity?.Name;
        foreach (var entityEntry in entities)
        {
            if (entityEntry.State != EntityState.Added)
            {
                continue;
            }
            
            var entity = (BaseAuditEntity) entityEntry.Entity;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = userName;
        }
    }
}