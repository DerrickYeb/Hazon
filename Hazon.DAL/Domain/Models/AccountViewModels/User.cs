using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Hazon.DAL.Domain.Models.AccountViewModels
{
    public class User:IdentityUser,IBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; }
        public string Contact { get; set; }
        public string RoleTypeId { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public Guid Id { get; set; }
        public string TenantId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public interface IBaseEntity
    {
        public Guid Id { get; set; }
        public string TenantId { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
