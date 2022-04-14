using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hazon.DAL.Domain.Models.AccountViewModels;
using Hazon.DAL.Domain.SharedDto.AccountDtos;

namespace Hazon.DAL.Application.Abstractions
{
    public interface IAuthenticationRepository:ITransient
    {
        Task<User> AuthenticateUserAsync(AuthInputModel auth);
        Task<User> RegisterUserAsync(UserInputModel user);
        Task<bool> UpdateUserAsync(Guid userId, UserInputModel user);
    }

    public record AuthModel(string Username, string Password);
}
