using Reservas.Domain.Model.Pagos;
using System;

namespace Reservas.Domain.Factories
{
    public class ReciboFactory : IReciboFactory
    {
        public Recibo Create(Guid PagoId, string nroRecibo, decimal importeTotal, decimal importePagado)
        {
            return new Recibo(PagoId, nroRecibo, importeTotal, importePagado);
        }
    }
}
