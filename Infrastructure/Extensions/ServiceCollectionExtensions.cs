using Core.Application.Abstractions.Services.General;
using Core.Application.Extensions;
using Hangfire;
using Infrastructure.Identity.Permissions;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Extensions;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            //MapsterSettings.Configure();
            if (config.GetSection("CacheSettings:PreferRedis").Get<bool>())
            {
 
            }
            else
            {
                services.AddDistributedMemoryCache();
            }

            services.TryAdd(ServiceDescriptor.Singleton<ICacheService, CacheService>());
            //services.AddHealthCheckExtension();
            services.AddLocalization();
            services.AddServiceCollection();
            services.AddSettings(config);
            //services.AddPermissions(config);
            services.AddIdentity(config);
            services.AddMultitenancy<TenantDbContext, ApplicationDbContext>(config);
            services.AddHangfireServer();
            services.AddRouting(options => options.LowercaseUrls = true);
            // services.AddMiddlewares(config);
            // services.AddSwaggerDocumentation(config);
             //services.AddCorsPolicy();
            services.AddApiVersioning(config =>
           {
               config.DefaultApiVersion = new ApiVersion(1, 0);
               config.AssumeDefaultVersionWhenUnspecified = true;
               config.ReportApiVersions = true;
           });
            //services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            return services;
        }

        public static IServiceCollection AddPermissions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>()
                .AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            return services;
        }
    }
}