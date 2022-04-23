using System.ComponentModel.DataAnnotations;

namespace Hazon.DAL.Domain.Models.SetupModels;

public class BaseSetup:BaseEntity
{
    public Guid Id{get; set; }
    [Required]
    public string Code { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}