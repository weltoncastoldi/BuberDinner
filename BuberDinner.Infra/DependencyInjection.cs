using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Infra.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }

    }
}