using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Model.ReservaAnulados;
using Reservas.Domain.Repositories;
using Reservas.Infraestructure.EF.Contexts;
using System;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.Repository
{
    public class ReservaAnuladoRepository : IReservaAnuladoRepository
    {
        public readonly DbSet<ReservaAnulado> _anulacion;

        public ReservaAnuladoRepository(WriteDbContext context)
        {
            _anulacion = context.Anulacion;
        }
        public async Task CreateAsync(ReservaAnulado obj)
        {
            await _anulacion.AddAsync(obj);
        }

        public Task<ReservaAnulado> FindByIdAsync(Guid id)
        {
            return _anulacion
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
