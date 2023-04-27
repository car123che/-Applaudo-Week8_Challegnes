using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MovieRental.Application.Pesistence.Contracts;
using System.Reflection;

namespace MovieRental.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }

    }

}
