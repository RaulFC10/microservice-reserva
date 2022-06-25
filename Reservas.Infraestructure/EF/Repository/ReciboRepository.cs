using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Repositories;
using Reservas.Infraestructure.EF.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.Repository
{
    public class ReciboRepository : IReciboRepository
    {
        public readonly DbSet<Recibo> _recibo;

        public ReciboRepository(WriteDbContext context)
        {
            _recibo = context.Recibo;
        }
        public async Task CreateAsync(Recibo obj)
        {
            await _recibo.AddAsync(obj);
        }

        public Task<Recibo> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
