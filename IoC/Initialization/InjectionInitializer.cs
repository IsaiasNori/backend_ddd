using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;

namespace IoC.Initialization
{
    public static class InjectionInitializer
    {
        public static void InjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

        }
    }

}