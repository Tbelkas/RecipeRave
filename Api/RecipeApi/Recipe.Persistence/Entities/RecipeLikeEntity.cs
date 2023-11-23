using Recipe.Common.Models;
namespace Recipe.Persistence.Entities;

public class RecipeLikeEntity : BaseDateEntity
{
    public int UserId;
    public AppUserEntity AppUser;
    public int RecipeId;
    public RecipeEntity Recipe;
}