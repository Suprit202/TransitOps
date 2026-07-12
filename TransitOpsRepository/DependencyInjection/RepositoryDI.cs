using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TransitOpsRepository.Models;

namespace TransitOpsRepository.DependencyInjection
{
    public static class RepositoryDI
    {
        public static IServiceCollection AddRepositoryDI(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TransitOpsDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
