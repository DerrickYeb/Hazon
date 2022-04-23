using System.ComponentModel.DataAnnotations;

namespace Hazon.DAL.Domain.Models
{
    public class ClientDetailsModel:BaseEntity
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
        public string DOB { get; set; }
        [Required]
        public Guid ClientTypeId { get; set; }

    }
}
