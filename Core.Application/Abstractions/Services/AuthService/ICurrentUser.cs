using System.Security.Claims;
using Core.Application.Repositories;

namespace Core.Application.Abstractions.Services.AuthService
{
    public interface ICurrentUser : ITransientService
    {
        string Name { get; }
        Guid GetUserId();
        string GetUserEmail();
        string GetTenantKey();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetUserClaims();
    }
}