using System.Reflection;

namespace truckspot_api.Config.Extensions;

public static class ControllerExtensions
{
    public static IMvcBuilder AddAppControllers(this IServiceCollection services)
    {
        return services
            .AddControllers()
            .AddApplicationPart(Assembly.GetExecutingAssembly());
    }
}