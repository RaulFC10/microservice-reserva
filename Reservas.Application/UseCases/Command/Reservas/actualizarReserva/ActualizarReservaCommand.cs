using MediatR;
using Reservas.Application.Dto.Reserva;
using System;
using System.Collections.Generic;

namespace Reservas.Application.UseCases.Command.Reservas.actualizarReserva
{
    public class ActualizarReservaCommand : IRequest<Guid>
    {
        private ActualizarReservaCommand() { }

        public ActualizarReservaCommand(List<VueloReservaDto> detalle)
        {
            Detalle = detalle;
        }
        public Guid Id { get; set; }
        public Guid IdVuelo { get; set; }
        public List<VueloReservaDto> Detalle { get; set; }
    }
}
