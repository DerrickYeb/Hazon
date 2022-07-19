using Core.Application;
using Core.Application.Abstractions.Services.AuthService;
using Core.Application.Abstractions.Services.General;
using Core.Application.Settings;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Shared.DTO.Multitenancy;
using System.Text;

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
        private readonly ISerializerService _serializerService;

        public TenantServices(TenantDbContext context,
                              IOptions<MultitenancySettings> tenantSettings,
                              ICurrentUser currentUser,
                              ICacheService cacheService,
                              TenantDto currentDto,
                              HttpContext httpContext,
                              ISerializerService serializerService)
        {
            _context = context;
            _tenantSettings = tenantSettings.Value;
            _currentUser = currentUser;
            _cacheService = cacheService;
            _currentDto = currentDto;
            _httpContext = httpContext;
            _serializerService = serializerService;

            if(_httpContext != null)
            {
                if (_currentUser.IsAuthenticated())
                {
                    SetTenant(_currentUser.GetTenantKey());
                }
                else
                {
                    string tenantFromQueryString = System.Web.HttpUtility.ParseQueryString(_httpContext.Request.QueryString.Value!).Get("tenantKey")!;

                    if(tenantFromQueryString != null)
                    {
                        SetTenant(tenantFromQueryString);
                    }
                    else if(_httpContext.Request.Headers.TryGetValue("tenantKey",out var tenantKey))
                    {
                        SetTenant(tenantKey);
                    }
                    else
                    {
                        throw new UnauthorizedAccessException();
                    }

                }
            }
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
            byte[]? cacheData = string.IsNullOrEmpty(cachekey) ? null : _cacheService.GetAsync(cachekey).Result;
            if(cacheData != null)
            {
                _cacheService.RefreshAsync(cachekey).Wait();
                tenantDto = _serializerService.Deserialize<TenantDto>(Encoding.Default.GetString(cacheData));
            }
            else
            {
                var tenant = _context.Tenants.Where(c => c.Key == tenantId).FirstOrDefaultAsync().Result;
                tenantDto = new TenantDto
                {
                    Key = tenant.Key,
                    Name = tenant.Name,
                    AdminEmail = tenant.AdminEmail,
                    IsActive = tenant.IsActive,
                    ConnectionString = tenant.ConnectionString,
                    ValidUpto = tenant.ValidUpto
                };

                if(tenantDto != null)
                {
                    var options = new DistributedCacheEntryOptions();
                    byte[] serializeData = Encoding.Default.GetBytes(_serializerService.Serialize(tenantDto));
                    _cacheService.SetAsync(cachekey, serializeData, options).Wait();
                }
            }

            if(tenantDto == null)
            {
                //return custom tenant error here
            }
            if(tenantDto?.Key != "")
            {
                if (!tenantDto.IsActive)
                {
                    //return inactive error here
                }

                if(DateTime.UtcNow > tenantDto.ValidUpto)
                {
                    //return subscription error here
                }
            }
            _currentDto = tenantDto;

            if (string.IsNullOrEmpty(tenantDto.ConnectionString))
            {
                SetDefaultConnectionStringToCurrentTenant();
            }
        }
    }
}
