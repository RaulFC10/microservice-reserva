using ShareKernel.Core;
using System;

namespace Reservas.Domain.Event
{
    public record AnulacionRegistrada : DomainEvent
    {
        public Guid AnulacionId { get; }
        public Guid ReservaId { get; }
        public string Descripcion { get; }

        public AnulacionRegistrada(Guid anulacionId, Guid reservaId, string descripcion) : base(DateTime.Now)
        {
            AnulacionId = anulacionId;
            ReservaId = reservaId;
            Descripcion = descripcion;
        }

        
    }
}
