namespace truckspot_api.Config.Extensions;

public static class SwaggerBuilderExtension
{
    public static IApplicationBuilder BuildSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger().UseSwaggerUI(
            options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "api/swagger";
                
            });
        
        return app;
    }
}