using truckspot_api.Config.Database;

namespace truckspot_api.Config.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TruckSpotDatabaseSettings>(configuration.GetSection("MongoDbSettings"));
        services.AddSingleton<TruckSpotDatabaseService>();
        
        return services;
    }
}