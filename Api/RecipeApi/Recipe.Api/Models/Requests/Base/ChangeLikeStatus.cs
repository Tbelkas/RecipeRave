// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Recipe.Api.Models.Requests.Base;

public abstract class ChangeLikeStatus
{
    public int RecipeId { get; set; }
}