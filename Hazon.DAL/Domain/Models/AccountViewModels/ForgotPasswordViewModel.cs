using System.ComponentModel.DataAnnotations;

namespace Hazon.DAL.Domain.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
