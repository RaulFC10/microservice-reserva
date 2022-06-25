using Reservas.Domain.Factories;
using System;
using Xunit;

namespace Reservas.Test.Domain.Factories
{
    public class FacturaFactory_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var pagoIdTest = Guid.NewGuid();
            var nroFacturaTest = "R-1111";
            var importeTest = 500;

            var factory = new FacturaFactory();
            var factura = factory.Create(pagoIdTest, nroFacturaTest, importeTest);

            Assert.NotNull(factura);
            Assert.Equal(nroFacturaTest, factura.NroFactura);
            Assert.Equal(importeTest, factura.Importe);

        }
    }
}
