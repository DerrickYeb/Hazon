using Core.Application.Abstractions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<IRequestValidator>();
            return services;
        }
    }
}
