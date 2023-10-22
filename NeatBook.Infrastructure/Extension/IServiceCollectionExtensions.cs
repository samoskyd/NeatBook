using Microsoft.Extensions.DependencyInjection;
using NeatBook.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using NeatBook.Infrastructure.Config;

namespace NeatBook.Infrastructure.Extension
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<IConfigurationService, ConfigurationService>();
            //services.AddDbContext<NeatBookDbContext>();
            services.AddDbContext(configuration);
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NeatBookDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
