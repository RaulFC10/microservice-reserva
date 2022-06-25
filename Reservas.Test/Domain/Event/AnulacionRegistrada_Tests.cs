using Reservas.Domain.Event;
using System;
using Xunit;

namespace Reservas.Test.Domain.Event
{
    public class AnulacionRegistrada_Tests
    {

        [Fact]
        public void AnulacionRegistrada_CheckPropertiesValid()
        {
            var anulacionIdTest = Guid.NewGuid();
            var reservaIdTest = Guid.NewGuid();
            var descripcionTest = "reserva no pagada";

            var obj = new AnulacionRegistrada(
                anulacionIdTest,
                reservaIdTest,
                descripcionTest);

            Assert.Equal(anulacionIdTest, obj.AnulacionId);
            Assert.Equal(reservaIdTest, obj.ReservaId);
            Assert.Equal(descripcionTest, obj.Descripcion);
        }
    }
}
