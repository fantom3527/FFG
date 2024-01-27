using FFG.Application.Abstractions;
using FFG.Application.Abstractions.Repositories;
using FFG.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FFG.Infrastructure.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureDataAccess(this IServiceCollection services)
        {
            services.AddScoped<ICodeValueRepository, CodeValueRepository>();
            services.AddScoped<IFFGDbContext>(provider => provider.GetService<FFGDbContext>());

            return services;
        }
    }
}
