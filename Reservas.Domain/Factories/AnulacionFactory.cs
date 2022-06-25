using Reservas.Domain.Model.ReservaAnulados;
using System;

namespace Reservas.Domain.Factories
{
    public class AnulacionFactory : IAnulacionFactory
    {
        public ReservaAnulado Create(string descripcion, Guid reservaId)
        {
            return new ReservaAnulado(descripcion, reservaId);
        }
    }
}
