using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Repositories;
using Reservas.Infraestructure.EF.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.Repository
{
    public class PagoRepository : IPagoRepository
    {
        public readonly DbSet<Pago> _pagos;

        public PagoRepository(WriteDbContext context)
        {
            _pagos = context.Pago;
        }
        public async Task CreateAsync(Pago obj)
        {
            await _pagos.AddAsync(obj);
        }

        public decimal ObtTotalImporte(Guid idReserva)
        {
            return (from pag in _pagos.AsEnumerable()
                                 where pag.ReservaId == idReserva
                                 select pag).Sum(p => p.ImportePagado);
        }

        public Task<Pago> FindByIdAsync(Guid id)
        {
            return _pagos
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
