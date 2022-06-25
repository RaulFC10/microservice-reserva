using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class ReservaReadModel
    {
        public Guid Id { get; set; }
        public string NroReserva { get; set; }
        public decimal Costo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVuelo { get; set; }
        public TimeSpan Hora { get; set; }
        public TimeSpan HoraLimite { get; set; }
        public char Estado { get; set; }
        public bool Activo { get; set; }
        public Guid IdVuelo { get; set; }
        public ICollection<VueloReservaReadModel> VueloReserva { get; set; }
        public ICollection<PagoReadModel> Pago { get; set; }
        public ICollection<ReservaAnuladoReadModel> Anulacion { get; set; }
    }
}
