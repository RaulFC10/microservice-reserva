using Reservas.Domain.Event;
using Reservas.Domain.Model.Reservas.ValueObjects;
using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;

namespace Reservas.Domain.Model.Pagos
{
    public class Factura : AggregateRoot<Guid>
    {
        public NumeroReserva NroFactura { get; private set; }
        public DateTime Fecha { get; private set; }
        public PrecioValue Importe { get; private set; }
        public Guid PagoId { get; private set; }
        private Factura()
        {

        }
        public Factura(Guid pagoId, string nroFactura, decimal importe)
        {
            Id = Guid.NewGuid();
            PagoId = pagoId;
            NroFactura = nroFactura;
            Fecha = DateTime.Now;
            Importe = importe;
        }

        public void ConsolidarFactura(Guid ReservaId)
        {
            var evento = new FacturaCreado(Id, ReservaId, Importe, NroFactura);
            AddDomainEvent(evento);
        }
    }
}
