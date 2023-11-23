using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Persistence.Entities;

[Table("Ingredients")]
public class IngredientEntity : BaseEntity
{
    public string Name { get; set; }
}