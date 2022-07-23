using Core.Application.Abstractions;
using Core.Application.Repositories;
using Core.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Application.Services.AuthService
{
    public class AuthenticationService : IAuthenticationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<User> _repository;

        public AuthenticationService(IConfiguration configuration, IRepository<User> repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public async Task<Tokens> AuthenticateUserAsync(AuthInputModel auth)
        {
            var user = await _repository.ExistAsync<User>(c =>
                c.Username == auth.Username && c.Password == auth.Password);
            if (user == null) throw new Exception($"User with username {auth.Username} does not exist");
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
                TenantId = user.TenantKey,
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
                TenantKey = user.TenantId,
                Username = user.Username,
            };
            var userAsync = await _repository.CreateAsync(userOr);
            await _repository.SaveChangesAsync();
            return userAsync;
        }

        public async Task<bool> UpdateUserAsync(Guid userId, UserInputModel user)
        {
            var checkUserExist = await _repository.ExistAsync<User>(c => c.Id == userId);
            if (checkUserExist == null) throw new Exception("User not found to update");
            checkUserExist.Username = user.Username;
            checkUserExist.Password = user.Password;
            checkUserExist.Email = user.Email;
            checkUserExist.Contact = user.Contact;
            checkUserExist.FirstName = user.FirstName;
            checkUserExist.LastName = user.LastName;
            checkUserExist.ProfilePicture = user.ProfilePicture;
            checkUserExist.PhoneNumber = user.PhoneNumber;
            checkUserExist.RoleTypeId = checkUserExist.RoleTypeId;

            await _repository.UpdateAsync(checkUserExist);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserProfile(string username, string tenantKey)
        {
            try
            {
                var profile =
                    await _repository.ExistAsync<User>(c => c.TenantKey == tenantKey && c.Username == username);
                return profile;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }


}
