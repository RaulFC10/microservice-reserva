using MediatR;
using Microsoft.EntityFrameworkCore;
using Reservas.Application.Dto.Reserva;
using Reservas.Application.UseCases.Queries.Reservas.SearchReservas;
using Reservas.Infraestructure.EF.Contexts;
using Reservas.Infraestructure.EF.ReadModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.UseCases.Queries.Reservas
{
    public class SearchReservasHandler :
        IRequestHandler<SearchReservasQuery, ICollection<ReservaDto>>
    {

        private readonly DbSet<ReservaReadModel> _reservas;

        public SearchReservasHandler(ReadDbContext context)
        {
            _reservas = context.Reserva;
        }
        public async Task<ICollection<ReservaDto>> Handle(SearchReservasQuery request, CancellationToken cancellationToken)
        {
            var reservaList = await _reservas
                            .AsNoTracking()
                            .Include(x => x.VueloReserva)
                            .Where(x => x.NroReserva.Contains(request.NroReserva))
                            .ToListAsync();

            var result = new List<ReservaDto>();

            foreach (var objReserva in reservaList)
            {
                var reservaDto = new ReservaDto()
                {
                    Id = objReserva.Id,
                    NroReserva = objReserva.NroReserva,
                    IdVuelo = objReserva.IdVuelo,
                    Costo = objReserva.Costo
                };

                foreach (var item in objReserva.VueloReserva)
                {
                    reservaDto.VueloReserva.Add(new VueloReservaDto()
                    {
                        Costo = item.Costo,
                        IdPasajero = item.IdPasajero,
                    });
                }
                result.Add(reservaDto);
            }

            return result;
        }
    }
}
