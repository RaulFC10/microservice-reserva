using Reservas.Domain.Factories;
using System;
using Xunit;

namespace Reservas.Test.Domain.Factories
{
    public class AnulacionFactory_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var descripcionTest= "reserva no pagada";
            var reservaIdTest = Guid.NewGuid();
            var factory = new AnulacionFactory();
            var anulacion = factory.Create(descripcionTest, reservaIdTest);

            Assert.NotNull(anulacion);
            Assert.Equal(descripcionTest, anulacion.Descripcion);
            Assert.Equal(reservaIdTest, anulacion.ReservaId);

        }
    }
}
