using Reservas.Domain.Model.Pagos;
using System;
using Xunit;

namespace Reservas.Test.Domain.Model
{
    public class FacturaTests
    {
        [Fact]
        public void Factura_CheckPropertiesValid()
        {
            var pagoIdTest =  Guid.NewGuid();
            var nroFacturaTest = "F-1111";
            var importeTest = 500;

            var obj = new Factura(pagoIdTest, nroFacturaTest, importeTest);

            Assert.Equal(500, obj.Importe);
            Assert.Equal("F-1111", obj.NroFactura);
            Assert.Equal(pagoIdTest, obj.PagoId);
        }

        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (Factura)Activator.CreateInstance(typeof(Factura), true);
            Assert.Equal(Guid.Empty, command.Id);
        }
    }
}
