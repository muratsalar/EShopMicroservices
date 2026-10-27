namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            // Add API services here
            //services.AddCarter();
            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            // Configure API services here
            //app.MapCarter();
            return app;
        }
    }
}
