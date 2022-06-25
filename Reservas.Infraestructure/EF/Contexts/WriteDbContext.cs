using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Event;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Model.ReservaAnulados;
using Reservas.Domain.Model.Reservas;
using Reservas.Infraestructure.EF.Config.WriteConfig;
using ShareKernel.Core;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Contexts
{
    [ExcludeFromCodeCoverage]
    public class WriteDbContext : DbContext
    {
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Recibo> Recibo { get; set; }
        public virtual DbSet<ReservaAnulado> Anulacion { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var reservaConfig = new ReservaWriteConfig();
            modelBuilder.ApplyConfiguration<Reserva>(reservaConfig);
            modelBuilder.ApplyConfiguration<VueloReserva>(reservaConfig);
            
            var PagoConfig = new PagoWriteConfig();
            modelBuilder.ApplyConfiguration<Pago>(PagoConfig);
            

            var FacturaConfig = new FacturaWriteConfig();
            modelBuilder.ApplyConfiguration<Factura>(FacturaConfig);
           
            var ReciboConfig = new ReciboWriteConfig();
            modelBuilder.ApplyConfiguration<Recibo>(ReciboConfig);
        
           var ReservaAnuladoConfig = new ReservaAnuladoWriteConfig();
           modelBuilder.ApplyConfiguration<ReservaAnulado>(ReservaAnuladoConfig);
        
            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<ReservaCreado>();
            modelBuilder.Ignore<PagoRegistrado>();
            modelBuilder.Ignore<FacturaCreado>();//op
            modelBuilder.Ignore<ItemReservaAgregado>();
        }
    }
}
