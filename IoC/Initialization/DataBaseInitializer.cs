using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;

namespace IoC.Initialization
{
    public static class DataBaseInitializer
    {
        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
        {
            var teste = config.GetConnectionString("CoreContextConnection");

            services.AddDbContextPool<CoreContext>(options => options
                .UseSqlServer(config.GetConnectionString("CoreContextConnection")));
        }
    }

}