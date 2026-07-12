using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TransitOpsRepository.DependencyInjection;

namespace TransitOpsService.DependencyInjection
{
    public static class ServiceDI
    {
        public static IServiceCollection AddServiceDI(this IServiceCollection services, string connectionString)
        {
            services.AddRepositoryDI(connectionString);
            return services;
        }
    }
}
