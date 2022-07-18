using Shared.DTO.Multitenancy;

namespace Core.Application.Abstractions.Services.General
{
    public interface ITenantService : IScopedService
    {
        public void SetTenant(string tenantId);
        public string SetDefaultConnectionStringToCurrentTenant();
        public string GetDatabaseProvider();
        public string GetConnectionString();
        public TenantDto GetCurrentTenant();
    }

    public interface IScopedService
    {
        
    }
}