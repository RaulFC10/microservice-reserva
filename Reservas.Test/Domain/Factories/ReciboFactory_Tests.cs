using Reservas.Domain.Factories;
using System;
using Xunit;

namespace Reservas.Test.Domain.Factories
{
    public class ReciboFactory_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var PagoIdTest = Guid.NewGuid();
            var nroReciboTest = "R-1111";
            var importeTotalTest = 500;
            var importePagadoTest = 300;

            var factory = new ReciboFactory();
            var recibo = factory.Create(PagoIdTest, nroReciboTest, importeTotalTest, importePagadoTest);

            Assert.NotNull(recibo);
            Assert.Equal(PagoIdTest, recibo.PagoId);
            Assert.Equal(importeTotalTest, recibo.ImporteTotal);
            Assert.Equal(importePagadoTest, recibo.ImportePagado);

        }
    }
}
