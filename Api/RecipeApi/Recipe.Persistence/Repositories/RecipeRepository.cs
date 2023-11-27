using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Recipe.Persistence.Entities;
using Recipe.Persistence.Repositories.Interfaces;

namespace Recipe.Persistence.Repositories;

// todo: Query projection
public class RecipeRepository : IRecipeRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<RecipeRepository> _logger;

    // todo : Base?
    public RecipeRepository(AppDbContext dbContext, IMapper mapper, ILogger<RecipeRepository> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<RecipeEntity>> GetAllRecipes()
    {
        var recipes = await _dbContext.Recipes
            .Include(x => x.Ingredients)
            .Include(x => x.LikedUsers)
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();
        return recipes;
    }
    
    public async Task InsertRecipe(RecipeEntity entity)
    {
        await _dbContext.Recipes.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }    
        
    // todo: after moving to .net8 ExecuteDeleteAsync
    public async Task DeleteRecipe(RecipeEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync();
    }    
    
    // todo separate repo?
    public async Task LikeRecipe(RecipeLikeEntity entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }    
    
    public async Task UnlikeRecipe(RecipeLikeEntity entity)
    {
        _dbContext.RecipeLikes.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}