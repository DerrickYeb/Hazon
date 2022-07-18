using Core.Application.Abstractions.Services.AuthService;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class CurrentUser : ICurrentUser
    {
        private IHttpContextAccessor _httpAccesor;
        public CurrentUser(IHttpContextAccessor httpAccesor)
        {
            _httpAccesor = httpAccesor;
        }

        public string Name => _httpAccesor?.HttpContext?.User?.Identity?.Name!;

        public string GetTenantKey()
        {
            return IsAuthenticated() ? _httpAccesor?.HttpContext?.User?.GetTenantkey()! : string.Empty;
        }

        public IEnumerable<Claim> GetUserClaims()
        {
            return _httpAccesor?.HttpContext?.User.Claims!;
        }

        public string GetUserEmail()
        {
            return _httpAccesor?.HttpContext?.User.GetUserEmail() ?? string.Empty;
        }

        public Guid GetUserId() => IsAuthenticated() ? Guid.Parse(_httpAccesor.HttpContext?.User.GetUserId()
            ?? Guid.Empty.ToString()) : Guid.Empty;

        public bool IsAuthenticated()
        {
            return _httpAccesor?.HttpContext?.User.Identity?.IsAuthenticated ?? false;
        }

        public bool IsInRole(string role)
        {
            return _httpAccesor.HttpContext?.User?.IsInRole(role) ?? false;
        }
    }
}
