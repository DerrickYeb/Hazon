using System.ComponentModel.DataAnnotations;
using Core.Domain.Contracts;

namespace Core.Domain.Models.SetupModels;

public class BaseSetup:BaseEntity,IMustHaveTenant
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string TenantKey { get; set; }
}