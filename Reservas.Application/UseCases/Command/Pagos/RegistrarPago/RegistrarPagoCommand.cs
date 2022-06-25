using MediatR;
using Reservas.Application.Dto.Pago;
using System;

namespace Reservas.Application.UseCases.Command.Pagos.RegistrarPago
{
    public class RegistrarPagoCommand : IRequest<(Guid,string)>
    {
        public decimal ImportePagado { get; set; }
        public string NroReserva { get; set; }

        private RegistrarPagoCommand() { }
        public RegistrarPagoCommand(decimal importePagado, string nroReserva)
        {
            ImportePagado = importePagado;
            NroReserva = nroReserva;
        }
    
    }
}
