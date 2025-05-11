using Customer.Application;
using Customer.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.API.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, string connectionString)
    {
        services.AddApplication();
        services.AddInfrastructure(connectionString);

        return services;
    }
}
