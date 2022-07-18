using Core.Application;
using Core.Application.Abstractions.Services.AuthService;
using Core.Application.Abstractions.Services.General;
using Core.Application.Settings;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Shared.DTO.Multitenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TenantServices : ITenantService
    {
        private readonly HttpContext _httpContext;
        private TenantDto _currentDto;
        private ICacheService _cacheService;
        private ICurrentUser _currentUser;
        private MultitenancySettings _tenantSettings;
        private readonly TenantDbContext _context;

        public TenantServices(TenantDbContext context,IOptions<MultitenancySettings> tenantSettings, ICurrentUser currentUser, ICacheService cacheService, TenantDto currentDto, HttpContext httpContext)
        {
            _context = context;
            _tenantSettings = tenantSettings.Value;
            _currentUser = currentUser;
            _cacheService = cacheService;
            _currentDto = currentDto;
            _httpContext = httpContext;
        }

        public string GetConnectionString()
        {
            return _currentDto.ConnectionString;
        }

        public TenantDto GetCurrentTenant()
        {
            return _currentDto;
        }

        public string GetDatabaseProvider()
        {
            return _tenantSettings.DBProvider;
        }

        public string SetDefaultConnectionStringToCurrentTenant()
        {
            return _currentDto.ConnectionString = _tenantSettings.ConnectionString;
        }

        public void SetTenant(string tenantId)
        {
            TenantDto tenantDto;
            string cachekey = CacheKey.GetCachekey("tenant", tenantId);
            byte[]
        }
    }
}
