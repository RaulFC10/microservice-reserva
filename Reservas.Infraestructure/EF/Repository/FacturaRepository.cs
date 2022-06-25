using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Repositories;
using Reservas.Infraestructure.EF.Contexts;
using System;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        public readonly DbSet<Factura> _factura;

        public FacturaRepository(WriteDbContext context)
        {
            _factura = context.Factura;
        }

        public async Task CreateAsync(Factura obj)
        {
            await _factura.AddAsync(obj);
        }

        public Task<Factura> FindByIdAsync(Guid id)
        {
            return _factura
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
