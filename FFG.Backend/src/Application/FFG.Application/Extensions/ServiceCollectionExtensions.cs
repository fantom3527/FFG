using FFG.Application.Contracts.Services;
using FFG.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FFG.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICodeValueService, CodeValueService>();

            return services;
        }
    }
}
