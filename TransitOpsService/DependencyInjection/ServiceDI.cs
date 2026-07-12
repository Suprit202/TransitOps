using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TransitOpsRepository.DependencyInjection;
using TransitOpsService.Services;
using TransitOpsService.Services.IServices;

namespace TransitOpsService.DependencyInjection
{
    public static class ServiceDI
    {
        public static IServiceCollection AddServiceDI(this IServiceCollection services, string connectionString)
        {
            services.AddRepositoryDI(connectionString);
            services.AddScoped<IVehicleService, VehicleService>();
            return services;
        }
    }
}
