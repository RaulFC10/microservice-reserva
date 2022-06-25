using Reservas.Domain.Model.Pagos;
using ShareKernel.Core;
using System;

namespace Reservas.Domain.Repositories
{
    public interface IReciboRepository : IRepository<Recibo, Guid>
    {
    }
}
