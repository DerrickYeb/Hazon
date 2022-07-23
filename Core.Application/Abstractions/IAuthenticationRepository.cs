﻿using Core.Application.Abstractions.Services.General;
using Core.Application.Repositories;
using Core.Application.Services;
using Core.Application.Services.AuthService;
using Core.Domain.Models;

namespace Core.Application.Abstractions
{
    public interface IAuthenticationRepository:IScopedService
    {
        Task<Tokens> AuthenticateUserAsync(AuthInputModel auth);
        Task<User> RegisterUserAsync(UserInputModel user);
        Task<bool> UpdateUserAsync(Guid userId, UserInputModel user); 
        Task<User> GetUserProfile(string username, string tenantKey);
    }
}
