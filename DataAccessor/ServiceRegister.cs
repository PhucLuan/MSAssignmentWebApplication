using DataAccessor.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessor
{
    public static class ServiceRegister
    {
        public static void AddDataAccessorLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EcomStepMediaContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b =>
                    b.MigrationsAssembly(typeof(EcomStepMediaContext).Assembly.FullName)
                ));
        }
    }
}
