using System.ComponentModel.DataAnnotations;

namespace Recipe.Persistence.Entities;

public abstract class BaseDateEntity
{
    [Required]
    public DateTime CreatedDate { get; set; }
    //createdBy?
}