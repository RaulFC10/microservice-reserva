using Reservas.Domain.Model.ReservaAnulados;
using System;

namespace Reservas.Domain.Factories
{
    public interface IAnulacionFactory
    {
        ReservaAnulado Create(string descripcion, Guid reservaId);
    }
}
