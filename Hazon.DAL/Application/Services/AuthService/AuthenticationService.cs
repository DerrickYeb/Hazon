using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hazon.DAL.Application.Abstractions;
using Hazon.DAL.Domain.Data;
using Hazon.DAL.Domain.Models.AccountViewModels;
using Hazon.DAL.Domain.SharedDto.AccountDtos;
using Microsoft.EntityFrameworkCore;

namespace Hazon.DAL.Application.Services.AuthService
{
    public class AuthenticationService:IAuthenticationRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthenticationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AuthenticateUserAsync(AuthInputModel auth)
        {
            return (await _context.Users.Where(u => u.Username == auth.Username && u.Password == auth.Password).FirstOrDefaultAsync()!)!;
        }

        public async Task<User> RegisterUserAsync(UserInputModel user)
        {
            var userOr = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Contact = user.Contact,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                ProfilePicture = user.ProfilePicture,
                RoleTypeId = user.RoleTypeId,
                TenantId = user.TenantId,
                Username = user.Username,
            };
            var userAsync = await _context.Users.AddAsync(userOr);
            await _context.SaveChangesAsync();
            return userAsync.Entity;
        }

        public async Task<bool> UpdateUserAsync(Guid userId, UserInputModel user)
        {
            var checkUserExist = await _context.Users.FindAsync(userId);
            if (checkUserExist == null) return false;
            checkUserExist.Username = user.Username;
            checkUserExist.Password = user.Password;
            checkUserExist.Email = user.Email;
            checkUserExist.Contact = user.Contact;
            checkUserExist.FirstName = user.FirstName;
            checkUserExist.LastName = user.LastName;
            checkUserExist.ProfilePicture = user.ProfilePicture;
            checkUserExist.PhoneNumber = user.PhoneNumber;
            checkUserExist.RoleTypeId = checkUserExist.RoleTypeId;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
