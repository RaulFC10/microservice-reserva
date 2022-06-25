using Reservas.Domain.Event;
using ShareKernel.Core;
using System;

namespace Reservas.Domain.Model.ReservaAnulados
{
    public class ReservaAnulado : AggregateRoot<Guid>
    {
        public Guid ReservaId { get; private set; }
        public DateTime Fecha { get; private set; }
        public string Descripcion { get; private set; }

        private ReservaAnulado()
        {

        }
        public ReservaAnulado(string descripcion, Guid reservaId)
        {
            Id = Guid.NewGuid();
            ReservaId = reservaId;
            Fecha = DateTime.Now;
            Descripcion = descripcion;

        }

        public void ConsolidarAnulacion(Guid ReservaId, string descripcion)
        {
            var evento = new AnulacionRegistrada(Id, ReservaId, descripcion);
            AddDomainEvent(evento);
        }
    }
}
