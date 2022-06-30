using Core.Domain.Models.Multitenancy;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class TenantDbContext:DbContext
{
    public TenantDbContext(DbContextOptions<TenantDbContext> option):base(option)
    {
    }
    public DbSet<Tenant> Tenants { get; set; }
}