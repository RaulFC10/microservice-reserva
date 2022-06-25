using Reservas.Domain.Model.Reservas;
using ShareKernel.Core;
using System;
using System.Threading.Tasks;

namespace Reservas.Domain.Repositories
{
    public interface IReservaRepository : IRepository<Reserva, Guid>
    {
        Task UpdateAsync(Reserva obj);
        Task<Reserva> ObtReserva(string nroReserva);
    }
}
