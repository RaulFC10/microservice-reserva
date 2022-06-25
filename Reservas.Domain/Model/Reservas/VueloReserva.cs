using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;

namespace Reservas.Domain.Model.Reservas
{
    public class VueloReserva : Entity<Guid>
    {
        public Guid IdPasajero { get; private set; }
        public PrecioValue Costo { get; private set; }
        public bool Activo { get; private set; }

        internal VueloReserva(Guid idPasajero, decimal costo)
        {
            Id = Guid.NewGuid();
            IdPasajero = idPasajero;
            Costo = costo;
            Activo = true;
        }
        private VueloReserva() { }

        internal void ModificarReserva(Guid idPasajero, decimal costo)
        {
            Costo = costo;
            IdPasajero = idPasajero;
        }
    }
}
