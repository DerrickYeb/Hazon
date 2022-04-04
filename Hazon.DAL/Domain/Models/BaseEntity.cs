using System.ComponentModel.DataAnnotations;

namespace Hazon.DAL.Domain.Models;

public class BaseEntity
{
    public Guid Id { get; set; }
    public string TenantId { get; set; }
    [Required]
    public string CreatedBy { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
}