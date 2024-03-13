using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Cocktails.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            var assembly = typeof(ApplicationServicesRegistration).Assembly;
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);

            return services;
        }
    }
}