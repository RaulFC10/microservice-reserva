using Reservas.Domain.Model.Reservas;
using System;

namespace Reservas.Domain.Factories
{
    public interface IReservaFactory
    {
        Reserva Create(Guid idVuelo, string nroReserva, DateTime fechaVuelo);
    }
}
