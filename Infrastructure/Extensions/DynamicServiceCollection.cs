using Core.Application.Repositories;
using Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Extensions
{
    public static class DynamicServiceCollection
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services)
        {
            var transientType = typeof(ITransientService);
            var scopeServiceType = typeof(IServiceScope);
            var transientService = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(s => transientType.IsAssignableFrom(s))
                .Where(s => s.IsClass && !s.IsAbstract)
                .Select(s => new
                {
                    Services = s.GetInterfaces().FirstOrDefault(),
                    Implementation = s
                }).Where(s => s.Services != null);
            var scopService = AppDomain.CurrentDomain.GetAssemblies().
                SelectMany(s => s.GetTypes())
                .Where(s => scopeServiceType.IsAssignableFrom(s))
                .Where(s => s.IsClass && !s.IsAbstract)
                .Select(s => new
                {
                    Services = s.GetInterfaces().FirstOrDefault(),
                    Implementation = s
                }).Where(s => s.Services != null);
            //Transient Service
            foreach (var service in transientService)
            {
                if (transientType.IsAssignableFrom(service.Services))
                {
                    services.AddTransient(service.Services, service.Implementation);
                }
            }
            //Scope Service
            foreach (var service in scopService)
            {
                if (scopeServiceType.IsAssignableFrom(service.Services))
                {
                    services.AddScoped(service.Services, service.Implementation);
                }
            }

            return services;
        }
    }
}
