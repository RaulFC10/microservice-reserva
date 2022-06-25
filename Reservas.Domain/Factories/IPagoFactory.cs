using Reservas.Domain.Model.Pagos;
using System;

namespace Reservas.Domain.Factories
{
    public interface IPagoFactory
    {
        Pago Create(Guid ReservaId, decimal importe, decimal importePagado);
    }
}
