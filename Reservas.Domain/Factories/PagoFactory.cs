using Reservas.Domain.Model.Pagos;
using System;

namespace Reservas.Domain.Factories
{
    public class PagoFactory : IPagoFactory
    {
        public Pago Create(Guid ReservaId, decimal importe, decimal importePagado)
        {
            return new Pago(ReservaId, importe , importePagado);
        }
    }
}
