using Reservas.Domain.Model.ReservaAnulados;
using ShareKernel.Core;
using System;

namespace Reservas.Domain.Repositories
{
    public interface IReservaAnuladoRepository : IRepository<ReservaAnulado, Guid>
    {
    }
}
