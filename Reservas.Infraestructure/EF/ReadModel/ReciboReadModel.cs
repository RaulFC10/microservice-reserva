using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class ReciboReadModel
    {
        public Guid Id { get; set; }
        public string NroRecibo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal ImporteTotal { get; set; }
        public decimal ImportePagado { get; set; }
        public decimal Saldo { get; set; }
        public PagoReadModel Pago { get; set; }
    }
}
