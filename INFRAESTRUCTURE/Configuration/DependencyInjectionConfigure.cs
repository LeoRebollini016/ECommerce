using APPLICATION;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace INFRAESTRUCTURE.Configuration;

public static class DependencyInjectionConfigure
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfraestructure(configuration);
        services.AddApplication(configuration);
        return services;
    }
}