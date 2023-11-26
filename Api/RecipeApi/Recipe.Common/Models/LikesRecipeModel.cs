namespace Recipe.Common.Models;

public class LikesRecipeModel : RecipeModel
{
    public int LikeCount { get; set; }
    public bool HasUserLiked { get; set; }
}