using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservas.Application;
using Reservas.Domain.Repositories;
using Reservas.Infraestructure.EF;
using Reservas.Infraestructure.EF.Contexts;
using Reservas.Infraestructure.EF.Repository;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Reservas.Infraestructure
{
    [ExcludeFromCodeCoverage]
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            var connectionString =
                configuration.GetConnectionString("ReservaDbConnectionString");

            services.AddDbContext<ReadDbContext>(context =>
                context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context =>
                context.UseSqlServer(connectionString));


            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<IPagoRepository, PagoRepository>();
            services.AddScoped<IFacturaRepository, FacturaRepository>();
            services.AddScoped<IReciboRepository, ReciboRepository>();
            services.AddScoped<IReservaAnuladoRepository, ReservaAnuladoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }

    }
}
