using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Persistence.Entities;

public abstract class BaseEntity : BaseDateEntity 
{
    [Key]
    [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}