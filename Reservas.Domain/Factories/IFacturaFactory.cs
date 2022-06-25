using Reservas.Domain.Model.Pagos;
using System;

namespace Reservas.Domain.Factories
{
    public interface IFacturaFactory
    {
        Factura Create(Guid PagoId, string nroFactura, decimal importe);
    }
}
