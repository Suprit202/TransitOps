using TransitOpsService.DependencyInjection;

namespace TransitOps.DependecyInjection
{
    public static class UserInterfaceDI
    {
        public static IServiceCollection AddUserInterfaceDI(this IServiceCollection services, string connectionString)
        {
            services.AddServiceDI(connectionString);
            return services;
        }
    }
}
