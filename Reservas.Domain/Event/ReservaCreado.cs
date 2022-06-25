using ShareKernel.Core;
using System;

namespace Reservas.Domain.Event
{
    public record ReservaCreado : DomainEvent
    {
        public Guid ReservaId { get; }
        public string NroReserva { get; }
        public decimal Costo { get; }
        public Guid IdVuelo { get; }
        public ReservaCreado(Guid reservaId, string nroReserva, decimal costo, Guid idVuelo) : base(DateTime.Now)
        {
            ReservaId = reservaId;
            NroReserva= nroReserva;
            Costo = costo;
            IdVuelo = idVuelo;
        }
    }
}
