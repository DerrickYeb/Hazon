namespace Hazon.DAL.Domain.SharedDto.AccountDtos
{
    public class UserInputModel
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
        public string TenantId { get; set; }
    }
}
