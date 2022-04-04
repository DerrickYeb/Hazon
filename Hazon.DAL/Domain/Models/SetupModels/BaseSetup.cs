using System.ComponentModel.DataAnnotations;

namespace Hazon.DAL.Domain.Models.SetupModels;

public class BaseSetup:BaseEntity
{

    [Required]
    public string Code { get; set; }
    [Required]
    public string Name { get; set; }
    public int Rate { get; set; }
    public string Description { get; set; }
}