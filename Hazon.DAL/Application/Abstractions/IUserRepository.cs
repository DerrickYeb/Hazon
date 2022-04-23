using Hazon.DAL.Domain.Models.AccountViewModels;

namespace Hazon.DAL.Application.Abstractions
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
    }

    
}
