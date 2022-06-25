using Reservas.Domain.Event;
using System;
using Xunit;

namespace Reservas.Test.Domain.Event
{
    public class FacturaCreado_Tests
    {
        [Fact]
        public void FacturaCreado_CheckPropertiesValid()
        {
            var facturaIdTest = Guid.NewGuid();
            var reservaIdTest = Guid.NewGuid();
            var nroFacturaTest = "F-1111";
            var importeTest = 500;

            var obj = new FacturaCreado(
                facturaIdTest,
                reservaIdTest,
                importeTest,
                nroFacturaTest
                );

            Assert.Equal(facturaIdTest, obj.FacturaId);
            Assert.Equal(reservaIdTest, obj.ReservaId);
            Assert.Equal(nroFacturaTest, obj.NroFactura);
            Assert.Equal(importeTest, obj.Importe);
        }
    }
}
