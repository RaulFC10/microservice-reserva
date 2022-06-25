using Reservas.Domain.Model.Pagos;
using System;
using Xunit;

namespace Reservas.Test.Domain.Model
{
    public class Recibo_Tests
    {
        [Fact]
        public void Recibo_CheckPropertiesValid()
        {
            var pagoIdTest = Guid.NewGuid();
            var nroReciboTest = "R-1111";
            var importeTotalTest = 500;
            var importePagadoTest = 300;

            var obj = new Recibo(pagoIdTest, nroReciboTest, importeTotalTest, importePagadoTest);

            Assert.Equal(nroReciboTest, obj.NroRecibo);
            Assert.Equal(importeTotalTest, obj.ImporteTotal);
            Assert.Equal(importePagadoTest, obj.ImportePagado);
        }
    }
}
