using System;
using System.Collections.Generic;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class PagoReadModel
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public decimal ImportePagado { get; set; }
        public ReservaReadModel Reserva { get; set; }
        public ICollection<FacturaReadModel> Factura { get; set; }
    }
}
