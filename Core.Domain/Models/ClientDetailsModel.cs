using System.ComponentModel.DataAnnotations;
using Core.Domain.Contracts;

namespace Core.Domain.Models
{
    public class ClientDetailsModel:AuditableEntity,IMustHaveTenant
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string CustomerCode { get; set; }
        [Required]
        public string Contact { get; set; }
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Guid ContactPersonId { get; set; }
        public string DOB { get; set; }
        [Required]
        public Guid ClientTypeId { get; set; }

        public string TenantKey { get; set; }
    }
}
