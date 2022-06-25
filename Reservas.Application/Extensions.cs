using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Reservas.Application.Service;
using Reservas.Application.Service.Interface;
using Reservas.Domain.Factories;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Reservas.Application
{
    [ExcludeFromCodeCoverage]
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IReservaService, ReservaService>();
            services.AddTransient<IReservaFactory, ReservaFactory>();

            services.AddTransient<IPagoFactory, PagoFactory>();


       
            services.AddTransient<IFacturaFactory, FacturaFactory>();
            services.AddTransient<IFacturaService, FacturaService>();

            services.AddTransient<IReciboFactory, ReciboFactory>();
            services.AddTransient<IReciboService, ReciboService>();

            services.AddTransient<IAnulacionFactory, AnulacionFactory>();


            return services;
        }
    }
}
