using System.ComponentModel.DataAnnotations;

namespace Hazon.DAL.Domain.Models.AccountViewModels
{
    public class LoginWithRecoveryCodeViewModel:BaseEntity
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Recovery Code")]
        public string RecoveryCode { get; set; }
    }
}
