using Reservas.Domain.Model.Reservas.ValueObjects;
using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;

namespace Reservas.Domain.Model.Pagos
{
    public class Recibo : AggregateRoot<Guid>
    {
        public NumeroReserva NroRecibo { get; private set; }
        public DateTime Fecha { get; private set; }
        public PrecioValue ImporteTotal { get; private set; }
        public PrecioValue ImportePagado { get; private set; }
        public PrecioValue Saldo { get; private set; }
        public Guid PagoId { get; private set; }
        private Recibo()
        {

        }

        public Recibo(Guid pagoId, string nroRecibo, decimal importeTotal, decimal importePagado)
        {
            Id = Guid.NewGuid();
            PagoId = pagoId;
            NroRecibo = nroRecibo;
            Fecha = DateTime.Now;
            ImporteTotal = importeTotal;
            ImportePagado = importePagado;
            Saldo = importeTotal - importePagado;
        }
    }
}
