namespace Recipe.Common.Models;

public class LikesRecipeModel : RecipeModel
{
    public int LikeCount { get; set; }
    public bool HasUserLiked { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
}