using Core.Domain.Models;

namespace Core.Application.Abstractions
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
    }

    
}
