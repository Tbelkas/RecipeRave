using System.ComponentModel.DataAnnotations;

namespace Recipe.Persistence.Entities;

public abstract class BaseAuditEntity
{
    [Required]
    public DateTime CreatedDate { get; set; }

    //todo: id instead of name
    public string? CreatedBy { get; set; }
}