using Reservas.Domain.Event;
using Reservas.Domain.ValueObjects;
using ShareKernel.Core;
using System;

namespace Reservas.Domain.Model.Pagos
{
    public class Pago : AggregateRoot<Guid>
    {
        public DateTime Fecha { get; private set; }
        public PrecioValue Importe { get; private set; }
        public PrecioValue ImportePagado { get; private set; }
        public Guid ReservaId { get; private set; }

        private Pago() { }
        public Pago(Guid reservaId, decimal importe ,decimal importePagado)
        {
            Id = Guid.NewGuid();
            ReservaId = reservaId;
            Fecha = DateTime.Now;
            Importe = importe;
            ImportePagado = importePagado;
        }

        public bool ValidadPago(decimal importeTotal, decimal importePagado)
        {
            var porcentaje = importeTotal / 2;
            if (importePagado < porcentaje)
            {
                throw new BussinessRuleValidationException("Tiene que depositar al menos 50% del monto");
            }
            return true;
        }

        public (string, decimal) ObtTipoandImporteDado(decimal importeTotal, decimal importePagado, decimal total)
        {
            string tipo = "Recibo";
            decimal importeDado = 0;

            if (importeTotal == importePagado)
            {
                tipo = "Factura";
            }
            else
            {
                if (total == 0)
                {
                    importeDado = importeTotal;
                    tipo = "Recibo";
                    ValidadPago(importeTotal, importePagado);
                }
                else
                {
                    decimal totalDado = total + importePagado;
                    if (importeTotal == totalDado)
                    {
                        tipo = "Factura";
                    }
                    else
                    {
                        importeDado = importeTotal - total;
                    }

                }
            }

            return (tipo, importeDado);


        }



        public void ConsolidarPago(Guid ReservaId,decimal importeDado, string tipo)
        {
            var evento = new PagoRegistrado(Id, ReservaId , Importe, importeDado, ImportePagado, tipo);
            AddDomainEvent(evento);
        }
    }
}
