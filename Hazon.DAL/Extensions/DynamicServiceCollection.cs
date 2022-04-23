using Hazon.DAL.Application.Abstractions.CRM;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hazon.DAL.Extensions
{
    public static class DynamicServiceCollection
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services)
        {
            var transientType = typeof(ITransient);
            var transientService = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(s => transientType.IsAssignableFrom(s))
                .Where(s => s.IsClass && !s.IsAbstract)
                .Select(s => new
                {
                    Services = s.GetInterfaces().FirstOrDefault(),
                    Implementation = s
                }).Where(s => s.Services != null);
            foreach (var service in transientService)
            {
                if (transientType.IsAssignableFrom(service.Services)) services.AddTransient(service.Services, service.Implementation);
            }

            return services;
        }
    }
}
