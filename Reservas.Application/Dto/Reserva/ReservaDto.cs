using System;
using System.Collections.Generic;

namespace Reservas.Application.Dto.Reserva
{
    public class ReservaDto
    {
        public Guid Id { get; set; }
        public Guid IdVuelo { get; set; }
        public string NroReserva { get; set; }
        public decimal Costo { get; set; }
        public ICollection<VueloReservaDto> VueloReserva { get; set; }

        public ReservaDto()
        {
            VueloReserva = new List<VueloReservaDto>();
        }
    }
}
