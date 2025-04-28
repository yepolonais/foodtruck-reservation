using AspNetCore.Identity.Mongo;
using AspNetCore.Identity.Mongo.Model;
using truckspot_api.Config.Database;
using truckspot_api.Modules.Auth.Models;

namespace truckspot_api.Config.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoDbSettings = configuration.GetSection("MongoDbSettings");
        
        services.Configure<TruckSpotDatabaseSettings>(mongoDbSettings);
        services.AddSingleton<TruckSpotDatabaseService>();
        
        services.AddIdentityMongoDbProvider<User>(identity =>
        {
            identity.Password.RequireDigit = false;
            identity.Password.RequireLowercase = false;
            identity.Password.RequireNonAlphanumeric = false;
            identity.Password.RequireUppercase = false;
            identity.Password.RequiredLength = 6;
        }, mongo =>
        {
            mongo.ConnectionString = "mongodb://mongodb:27017/TruckSpot";
        });

        return services;
    }
}