namespace Hazon.DAL.Domain.Models.AccountViewModels
{
    public class User:IBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; }
        public string Contact { get; set; }
        public string RoleTypeId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public Guid Id { get; set; }
        public string TenantId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
