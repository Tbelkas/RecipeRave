#pragma warning disable CS9113 // Parameter is unread.

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Recipe.Persistence.Entities;
using Recipe.Persistence.Repositories.Interfaces;

namespace Recipe.Persistence.Repositories;

// todo: Query projection
public class RecipeRepository(AppDbContext dbContext, IMapper mapper, ILogger<RecipeRepository> logger) : IRecipeRepository
{
    public async Task<List<RecipeEntity>> GetAllRecipes()
    {
        var recipes = await dbContext.Recipes
            .Include(x => x.Ingredients)
            .Include(x => x.LikedUsers)
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();
        return recipes;
    }
    
    public async Task InsertRecipe(RecipeEntity entity)
    {
        await dbContext.Recipes.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }    
        
    public async Task DeleteRecipe(int id)
    {
        await dbContext.Recipes.Where(x => x.Id == id).ExecuteDeleteAsync();
    }    
    
    // todo separate repo?
    public async Task LikeRecipe(RecipeLikeEntity entity)
    {
        await dbContext.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }    
    
    public async Task UnlikeRecipe(RecipeLikeEntity entity)
    {
        dbContext.RecipeLikes.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}