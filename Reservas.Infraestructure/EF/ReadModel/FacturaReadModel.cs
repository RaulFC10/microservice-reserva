using System;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class FacturaReadModel
    {
        public Guid Id { get; set; }
        public string NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public PagoReadModel Pago { get; set; }
    }
}
