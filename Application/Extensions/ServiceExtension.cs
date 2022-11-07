using System;
using System.Reflection;
using Application.CQRS.Queries.AccountQueries.LoginQuery;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ServiceExtension
    {
        public static void MediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(LoginQueryHandler).Assembly);
        }
    }
}

