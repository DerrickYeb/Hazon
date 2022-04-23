using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hazon.DAL.Application.Abstractions;
using Hazon.DAL.Domain.Data;
using Hazon.DAL.Domain.Models.AccountViewModels;
using Hazon.DAL.Domain.SharedDto.AccountDtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hazon.DAL.Application.Services.AuthService
{
    public class AuthenticationService:IAuthenticationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Tokens> AuthenticateUserAsync(AuthInputModel auth)
        {
            var user = (await _context.Users.Where(u => u.Username == auth.Username && u.Password == auth.Password).FirstOrDefaultAsync()!)!;
            if (user == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenSecret = Encoding.UTF8.GetBytes(_configuration["jwtTokenConfig:secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, auth.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenSecret), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePicture = user.ProfilePicture,
                Email = user.Email,
                RoleTypeId = user.RoleTypeId,
                PhoneNumber = user.PhoneNumber,
                TenantId = user.TenantId,
                Token = tokenHandler.WriteToken(token)
            };
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
