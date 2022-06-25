using Reservas.Domain.Model.Reservas;
using System;

namespace Reservas.Domain.Factories
{
    public class ReservaFactory : IReservaFactory
    {
        public Reserva Create(Guid idVuelo,string nroReserva, DateTime fechaVuelo)
        {
            return new Reserva(idVuelo, nroReserva, fechaVuelo);
        }
    }
}
