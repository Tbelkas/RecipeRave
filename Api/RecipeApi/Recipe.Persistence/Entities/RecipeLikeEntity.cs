using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Persistence.Entities;

[Table("RecipesLikes")]
public class RecipeLikeEntity : BaseAuditEntity
{
    public required string AppUserId;
    public AppUserEntity? AppUser;
    public int RecipeId;
    public RecipeEntity? Recipe;
}