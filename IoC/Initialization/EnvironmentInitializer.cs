using System.Text;
using Domain;
using Domain.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace IoC.Initialization
{
    public static class EnvironmentInitializer
    {
        public static void ConfigureEnvironment(this IServiceCollection services, IConfiguration configuration)
        {
            var teste = configuration.Get<Settings>();

            CoreConstants.SetSettings(configuration.GetSection("Settings").Get<Settings>());

            services.AddCors();

            services.AddControllers();

            var key = Encoding.ASCII.GetBytes(CoreConstants.Settings.Secret);

            services
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }

}