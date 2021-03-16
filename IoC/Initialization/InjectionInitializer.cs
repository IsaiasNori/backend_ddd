using Domain.Core.Repositories;
using Domain.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;

namespace IoC.Initialization
{
    public static class InjectionInitializer
    {
        public static void InjectDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
        }
    }

}