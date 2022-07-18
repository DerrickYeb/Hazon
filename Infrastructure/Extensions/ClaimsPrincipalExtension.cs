using System.Security.Claims;

namespace Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));

            return principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        }
        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));

            return principal?.FindFirst(ClaimTypes.Email)?.Value!;
        }

        public static string GetTenantkey(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));

            return principal?.FindFirst("tenantkey")?.Value!;
        }
    }
}
