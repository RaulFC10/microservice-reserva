using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Event;
using Reservas.Infraestructure.EF.Config.ReadConfig;
using Reservas.Infraestructure.EF.ReadModel;
using ShareKernel.Core;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Contexts
{
    [ExcludeFromCodeCoverage]
    public class ReadDbContext : DbContext
    {
        public virtual DbSet<ReservaReadModel> Reserva { set; get; }

        
        public virtual DbSet<PagoReadModel> Pago { set; get; }
        public virtual DbSet<FacturaReadModel> Factura { set; get; }
        public virtual DbSet<ReciboReadModel> Recibo { set; get; }
        public virtual DbSet<ReservaAnuladoReadModel> ReservaAnulado { set; get; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var reservaConfig = new ReservaReadConfig();
            modelBuilder.ApplyConfiguration<ReservaReadModel>(reservaConfig);
            modelBuilder.ApplyConfiguration<VueloReservaReadModel>(reservaConfig);
            
            var PagoConfig = new PagoReadConfig();
            modelBuilder.ApplyConfiguration<PagoReadModel>(PagoConfig);

            var FacturaConfig = new FacturaReadConfig();
            modelBuilder.ApplyConfiguration<FacturaReadModel>(FacturaConfig);

            var ReciboConfig = new ReciboReadConfig();
            modelBuilder.ApplyConfiguration<ReciboReadModel>(ReciboConfig);

            var ReservaAnuladoConfig = new ReservaAnuladoReadConfig();
            modelBuilder.ApplyConfiguration<ReservaAnuladoReadModel>(ReservaAnuladoConfig);
            
            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<ReservaCreado>();
            modelBuilder.Ignore<ItemReservaAgregado>();
        }
    }
}
