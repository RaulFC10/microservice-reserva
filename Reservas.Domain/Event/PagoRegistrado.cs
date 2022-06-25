using ShareKernel.Core;
using System;

namespace Reservas.Domain.Event
{
    public record PagoRegistrado : DomainEvent
    {
        public Guid PagoId { get; }
        public Guid ReservaId { get; }
        public decimal Importe { get; }
        public decimal ImporteDado { get; }
        public decimal ImportePagado { get; }
        public string Tipo { get; }

        public PagoRegistrado(Guid pagoId,Guid reservaId, decimal importe, decimal importeDado,
            decimal importePagado, string tipo) : base(DateTime.Now)
        {
            PagoId = pagoId;
            ReservaId = reservaId;
            Importe = importe;
            ImporteDado = importeDado;
            ImportePagado = importePagado;
            Tipo = tipo;
        }
    }
}
