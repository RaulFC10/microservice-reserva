using MediatR;
using Reservas.Application.Dto.Reserva;
using Reservas.Domain.Model.Reservas;
using System;
using System.Collections.Generic;

namespace Reservas.Application.UseCases.Command.Reservas.CrearReserva
{
    public class CrearReservaCommand : IRequest<Reserva>
    {
        private CrearReservaCommand() { }

        public CrearReservaCommand(List<VueloReservaDto> detalle, Guid idVuelo, DateTime fechaVuelo)
        {
            Detalle = detalle;
            IdVuelo = idVuelo;
            FechaVuelo = fechaVuelo;
        }
        public Guid IdVuelo { get; set; }
        public DateTime FechaVuelo{ get; set; }
        public List<VueloReservaDto> Detalle { get; set; }
    }
}
