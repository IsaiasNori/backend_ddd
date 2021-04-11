using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace IoC.Initialization
{
    public static class DataBaseInitializer
    {
        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoreContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("CoreContextConnection")));
        }
    }

}