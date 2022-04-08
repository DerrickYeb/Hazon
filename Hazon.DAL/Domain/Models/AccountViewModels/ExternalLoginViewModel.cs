using System.ComponentModel.DataAnnotations;

namespace Hazon.DAL.Domain.Models.AccountViewModels
{
    public class ExternalLoginViewModel:BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
