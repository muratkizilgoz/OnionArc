using System;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}

