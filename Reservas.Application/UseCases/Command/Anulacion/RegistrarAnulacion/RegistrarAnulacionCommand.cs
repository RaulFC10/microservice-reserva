using MediatR;
using System;

namespace Reservas.Application.UseCases.Command.Anulacion.RegistrarAnulacion
{
    public class RegistrarAnulacionCommand : IRequest<Guid>
    {
        public string NroReserva { get; set; }
        public string Descripcion { get; set; }
        private RegistrarAnulacionCommand(){}

        public RegistrarAnulacionCommand(string nroReserva, string descripcion)
        {
            NroReserva = nroReserva;
            Descripcion = descripcion;
        }
    }
}
