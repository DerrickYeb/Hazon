using Hazon.DAL.Application.Abstractions.CRM;
using Hazon.DAL.Application.Services.AuthService;
using Hazon.DAL.Domain.Models.AccountViewModels;
using Hazon.DAL.Domain.SharedDto.AccountDtos;

namespace Hazon.DAL.Application.Abstractions
{
    public interface IAuthenticationRepository:ITransient
    {
        Task<Tokens> AuthenticateUserAsync(AuthInputModel auth);
        Task<User> RegisterUserAsync(UserInputModel user);
        Task<bool> UpdateUserAsync(Guid userId, UserInputModel user);
    }
}
