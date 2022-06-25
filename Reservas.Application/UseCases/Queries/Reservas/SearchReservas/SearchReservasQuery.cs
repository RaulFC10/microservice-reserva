using MediatR;
using Reservas.Application.Dto.Reserva;
using System.Collections.Generic;

namespace Reservas.Application.UseCases.Queries.Reservas.SearchReservas
{
    public class SearchReservasQuery : IRequest<ICollection<ReservaDto>>
    {
        public string NroReserva { get; set; }
    }
}
