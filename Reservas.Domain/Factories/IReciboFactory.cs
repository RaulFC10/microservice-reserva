using Reservas.Domain.Model.Pagos;
using System;

namespace Reservas.Domain.Factories
{
    public interface IReciboFactory
    {
        Recibo Create(Guid PagoId, string nroRecibo, decimal importeTotal, decimal importePagado);
    }
}
