using truckspot_api.Modules.Auth.Repositories;

namespace truckspot_api.Config.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddAppRepositories(this IServiceCollection services)
    {
        services.AddScoped<UserRepository>();
        return services;
    }
}