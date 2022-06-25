using Reservas.Domain.Event;
using System;
using Xunit;

namespace Reservas.Test.Domain.Event
{
    public class PagoRegistrado_Tests
    {
        [Fact]
        public void AnulacionRegistrada_CheckPropertiesValid()
        {
            var PagoIdTest = Guid.NewGuid();
            var ReservaIdTest = Guid.NewGuid();
            var importeTest = 500;
            var importeDadoTest = 500;
            var importePagadoTest = 300;
            var tipoTest = "Factura";

            var obj = new PagoRegistrado(
                PagoIdTest,
                ReservaIdTest,
                importeTest,
                importeDadoTest,
                importePagadoTest,
                tipoTest
                );

            Assert.Equal(PagoIdTest, obj.PagoId);
            Assert.Equal(ReservaIdTest, obj.ReservaId);
            Assert.Equal(importeTest, obj.Importe);
            Assert.Equal(importeDadoTest, obj.ImporteDado);
            Assert.Equal(importePagadoTest, obj.ImportePagado);
            Assert.Equal(tipoTest, obj.Tipo);
        }
    }
}
