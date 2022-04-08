namespace Hazon.DAL.Domain.Models.AccountViewModels;

public class UserRoleViewModel:BaseEntity
{
    public int CounterId { get; set; }
    public string ApplicationUserId { get; set; }
    public string RoleName { get; set; }
    public bool IsHaveAccess { get; set; }
}