using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;

namespace Reservas.Domain.Event
{
    public record ItemReservaAgregado : DomainEvent
    {
        public Guid IdPasajero { get; }
        public PrecioValue Costo { get; }
        public ItemReservaAgregado(Guid idPasajero, PrecioValue costo) : base(DateTime.Now)
        {
            IdPasajero = idPasajero;
            Costo = costo;
        }
    }
}
