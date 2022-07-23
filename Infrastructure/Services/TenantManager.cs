using Core.Application.Abstractions.Services.AuthService;
using Core.Application.Abstractions.Services.General;
using Core.Application.Settings;
using Infrastructure.Identity.Models;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Shared.DTO.Multitenancy;

namespace Infrastructure.Services
{
    public class TenantManager : ITenantManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _appContext;
        private readonly IStringLocalizer<TenantServices> _localizer;

        private readonly MultitenancySettings _options;

        private readonly TenantDbContext _context;
        private readonly ICurrentUser _user;

        public TenantManager(ApplicationDbContext appContext, IStringLocalizer<TenantServices> localizer, IOptions<MultitenancySettings> options, TenantDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ICurrentUser user)
        {
            _appContext = appContext;
            _localizer = localizer;
            _options = options.Value;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _user = user;
        }

        //public async Task<TenantDto> GetByKeyAsync(string key)
        //{
        //    var tenant = await _context.Tenants.Where(a => a.Key == key).FirstOrDefaultAsync();
        //    if (tenant == null) throw new EntityNotFoundException(string.Format(_localizer["entity.notfound"], typeof(Tenant).Name, key));
        //    var tenantDto = tenant.Adapt<TenantDto>();
        //    return await Result<TenantDto>.SuccessAsync(tenantDto);
        //}

        //public async Task<Result<List<TenantDto>>> GetAllAsync()
        //{
        //    var tenants = await _context.Tenants.ToListAsync();
        //    var tenantDto = tenants.Adapt<List<TenantDto>>();
        //    return await Result<List<TenantDto>>.SuccessAsync(tenantDto);
        //}

        //public async Task<Result<object>> CreateTenantAsync(CreateTenantRequest request)
        //{
        //    if (_context.Tenants.Any(a => a.Key == request.Key)) throw new Exception("Tenant with same key exists.");
        //    if (string.IsNullOrEmpty(request.ConnectionString)) request.ConnectionString = _options.ConnectionString;
        //    bool isValidConnectionString = TenantBootstrapper.TryValidateConnectionString(_options, request.ConnectionString, request.Key);
        //    if (!isValidConnectionString) throw new Exception($"Failed to Establish Connection to Database. Please check your connection string.");
        //    var tenant = new Tenant(request.Name, request.Key, request.AdminEmail, request.ConnectionString);
        //    tenant.CreatedBy = _user.GetUserId();
        //    TenantBootstrapper.Initialize(_appContext, _options, tenant, _userManager, _roleManager);
        //    _context.Tenants.Add(tenant);
        //    await _context.SaveChangesAsync();
        //    return await Result<object>.SuccessAsync(tenant.Id);
        //}

        //public async Task<Result<object>> UpgradeSubscriptionAsync(UpgradeSubscriptionRequest request)
        //{
        //    var tenant = await _context.Tenants.Where(a => a.Key == request.Tenant).FirstOrDefaultAsync();
        //    if (tenant == null) throw new Exception("Tenant Not Found.");
        //    tenant.SetValidity(request.ExtendedExpiryDate);
        //    _context.Tenants.Update(tenant);
        //    await _context.SaveChangesAsync();
        //    return await Result<object>.SuccessAsync($"Tenant {request.Tenant}'s Subscription Upgraded. Now Valid till {tenant.ValidUpto}.");
        //}

        //public async Task<Result<object>> DeactivateTenantAsync(string tenantKey)
        //{
        //    var tenant = await _context.Tenants.Where(a => a.Key == tenantKey).FirstOrDefaultAsync();
        //    if (tenant == null) throw new Exception("Tenant Not Found.");
        //    if (!tenant.IsActive) throw new Exception("Tenant is already Deactivated.");
        //    tenant.Deactivate();
        //    _context.Tenants.Update(tenant);
        //    await _context.SaveChangesAsync();
        //    return await Result<object>.SuccessAsync($"Tenant {tenantKey} is now Deactivated.");
        //}

        //public async Task<Result<object>> ActivateTenantAsync(string tenantKey)
        //{
        //    var tenant = await _context.Tenants.Where(a => a.Key == tenantKey).FirstOrDefaultAsync();
        //    if (tenant == null) throw new Exception("Tenant Not Found.");
        //    if (tenant.IsActive) throw new Exception("Tenant is already Activated.");
        //    tenant.Activate();
        //    _context.Tenants.Update(tenant);
        //    await _context.SaveChangesAsync();
        //    return await Result<object>.SuccessAsync($"Tenant {tenantKey} is now Activated.");
        //}
    }
}