using Reservas.Domain.Factories;
using System;
using Xunit;

namespace Reservas.Test.Domain.Factories
{
    public class PagoFactory_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var reservaIdTest = Guid.NewGuid();
            var importeTest = 500;
            var importePagadoTest = 300;

            var factory = new PagoFactory();
            var pago = factory.Create(reservaIdTest, importeTest, importePagadoTest);

            Assert.NotNull(pago);
            Assert.Equal(importeTest, pago.Importe);
            Assert.Equal(importePagadoTest, pago.ImportePagado);

        }
    }
}
