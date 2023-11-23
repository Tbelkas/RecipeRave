using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Recipe.Persistence.Entities;
using Recipe.Persistence.Repositories.Interfaces;

namespace Recipe.Persistence.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly DbContextOptions<AppDbContext> _options;
    private readonly IMapper _mapper;
    private readonly ILogger<RecipeRepository> _logger;
    private AppDbContext Context => new(_options);

    // todo : Base?
    public RecipeRepository(DbContextOptions<AppDbContext> options, IMapper mapper, ILogger<RecipeRepository> logger)
    {
        _options = options;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<RecipeEntity>> GetAllRecipes()
    {
        var recipes = await Context.Recipes.Include(x => x.Ingredients).ToListAsync();
        return recipes;
    }
    
    public async Task InsertRecipe(RecipeEntity entity)
    {
        await using var context = Context;
        await context.Set<RecipeEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
    }    
    
    // todo separate repo?
    public async Task LikeRecipe(RecipeLikeEntity entity)
    {
        await using var context = Context;
        await context.Set<RecipeLikeEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
    }    
    
    public async Task UnlikeRecipe(RecipeLikeEntity entity)
    {
        await using var context = Context;
        context.Set<RecipeLikeEntity>().Remove(entity);
        await context.SaveChangesAsync();
    }
}