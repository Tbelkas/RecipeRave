﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recipe.Common;
using Recipe.Common.Models;
using Recipe.Persistence.Entities;

namespace Recipe.Persistence;

public class AppDbContext  : IdentityDbContext<AppUserEntity>
{
    public DbSet<IngredientEntity> Ingredients { get; set; }
    public DbSet<RecipeEntity> Recipes { get; set; }
    public DbSet<RecipeLikeEntity> RecipeLikes { get; set; }
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
       
        modelBuilder.Entity<RecipeLikeEntity>(entity => entity.HasKey(x => new { x.RecipeId, x.UserId }));
        modelBuilder.Entity<AppUserEntity>(entity => entity.ToTable("Auth_AppUsers"));
        modelBuilder.Entity<IdentityRole>(entity => entity.ToTable("Auth_Roles"));
        modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.ToTable("Auth_UserRoles"));
        modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable("Auth_UserClaims"));
        modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable("Auth_UserLogins"));
        modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable("Auth_RoleClaims"));
        modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.ToTable("Auth_UserTokens"));
    }
    
    public override int SaveChanges()
    {
        var entities = ChangeTracker.Entries().Where(x => x is { Entity: BaseDateEntity, State: EntityState.Added or EntityState.Modified });
        foreach (var entity in entities)
        {
            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).CreatedDate = DateTime.Now;
            }
        }
        return base.SaveChanges();
    }
}