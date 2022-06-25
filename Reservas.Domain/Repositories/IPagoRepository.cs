using Reservas.Domain.Model.Pagos;
using ShareKernel.Core;
using System;

namespace Reservas.Domain.Repositories
{
    public interface IPagoRepository : IRepository<Pago, Guid>
    {
        decimal ObtTotalImporte(Guid idReserva);
    }
}
