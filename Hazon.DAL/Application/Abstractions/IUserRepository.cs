using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hazon.DAL.Domain.Models.AccountViewModels;

namespace Hazon.DAL.Application.Abstractions
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
    }

    
}
