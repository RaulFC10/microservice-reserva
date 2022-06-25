using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Model.Reservas.ValueObjects;
using Reservas.Domain.Repositories;
using Reservas.Infraestructure.EF.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        public readonly DbSet<Reserva> _reservas;
        public ReservaRepository(WriteDbContext context)
        {
            _reservas = context.Reserva;
        }

        public async Task CreateAsync(Reserva obj)
        {
            await _reservas.AddAsync(obj);
        }

        public async Task<Reserva> FindByIdAsync(Guid id)
        {
            return await _reservas.Include("_vueloReserva")
                    .SingleAsync(x => x.Id == id);
        }

        public async Task<Reserva> ObtReserva(string nroReserva)
        {
            return await _reservas
                .Where(u => u.Activo == true)
                .FirstOrDefaultAsync(u => u.NroReserva == nroReserva);
        }

        public Task UpdateAsync(Reserva obj)
        {
            _reservas.Update(obj);

            return Task.CompletedTask;
        }
    }
}
