using System;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class ReservaAnuladoReadModel
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public ReservaReadModel Reserva { get; set; }
    }
}
