using APPLICATION;
using INFRAESTRUCTURE;

namespace API.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfraestructure(configuration);
        services.AddApplication(configuration);
        return services;
    }
}