namespace Recipe.Common.Models;

public class LikesRecipeModel : RecipeModel
{
    public int LikeCount { get; init; }
    public bool HasUserLiked { get; init; }
    public string? CreatedBy { get; init; }
    public DateTime CreatedDate { get; init; }
}