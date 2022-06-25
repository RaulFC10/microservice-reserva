using ShareKernel.Core;
using System;

namespace Reservas.Domain.Event
{
    public record FacturaCreado : DomainEvent
    {
        public Guid FacturaId { get; }
        public Guid ReservaId { get; }

        public string NroFactura { get; }
        public decimal Importe { get; }

        public FacturaCreado(Guid facturaId, Guid reservaId, decimal importe,
            string nroFactura) : base(DateTime.Now)
        {
            FacturaId = facturaId;
            ReservaId = reservaId;
            NroFactura = nroFactura;
            Importe = importe;
        }
    }
}
