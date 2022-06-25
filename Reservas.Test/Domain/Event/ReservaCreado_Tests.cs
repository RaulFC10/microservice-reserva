using Reservas.Domain.Event;
using System;
using Xunit;

namespace Reservas.Test.Domain.Event
{
    public class ReservaCreado_Tests
    {
        [Fact]
        public void ReservaCreado_CheckPropertiesValid()
        {
            var reservaIdTest = Guid.NewGuid();
            var nroReservaTest = "R-1111";
            var costoTest = 500;
            var idVueloTest = Guid.NewGuid();

            var obj = new ReservaCreado(
                reservaIdTest,
                nroReservaTest,
                costoTest, 
                idVueloTest);

            Assert.Equal(reservaIdTest, obj.ReservaId);
            Assert.Equal(nroReservaTest, obj.NroReserva);
            Assert.Equal(costoTest, obj.Costo);
            Assert.Equal(idVueloTest, obj.IdVuelo);
        }
    }
}
