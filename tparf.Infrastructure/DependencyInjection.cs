using Microsoft.Extensions.DependencyInjection;
using tparf.Application.Services.Common.Interfaces.Authentication;
using tparf.Application.Services.Common.Interfaces.Services;
using tparf.Infrastructure.Authentication;
using tparf.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using tparf.Application.Services.Common.Interfaces.Persistance;
using tparf.Infrastructure.Persistance;

namespace tparf.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider , DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
