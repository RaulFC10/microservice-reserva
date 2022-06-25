using System;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class VueloReservaReadModel
    {
        public Guid Id { get; set; }
        public decimal Costo { get; set; }
        public bool Activo { get; set; }
        public Guid IdPasajero { get; set; }
        public ReservaReadModel Reserva { get; set; }
    }
}
