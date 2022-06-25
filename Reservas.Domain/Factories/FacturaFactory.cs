using Reservas.Domain.Model.Pagos;
using System;

namespace Reservas.Domain.Factories
{
    public class FacturaFactory : IFacturaFactory
    {
        public Factura Create(Guid PagoId, string nroFactura, decimal importe)
        {
            return new Factura(PagoId, nroFactura, importe);
        }
    }
}
