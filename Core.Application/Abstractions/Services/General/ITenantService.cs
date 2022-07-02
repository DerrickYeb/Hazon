namespace Core.Application.Abstractions.Services.General
{
    public interface ITenantService : IScopedService
    {
        public string GetDatabaseProvider();
        public string GetConnectionString();
        // public TenantDto GetCurrentTenant();
    }

    public interface IScopedService
    {
        
    }
}