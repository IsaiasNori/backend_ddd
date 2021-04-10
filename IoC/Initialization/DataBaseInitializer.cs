using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;

namespace IoC.Initialization
{
    public static class DataBaseInitializer
    {
        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<CoreContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("CoreContextConnection")));
        }
    }

}