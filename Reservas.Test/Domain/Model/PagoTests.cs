using Reservas.Domain.Model.Pagos;
using ShareKernel.Core;
using System;
using Xunit;

namespace Reservas.Test.Domain.Model
{
    public class PagoTests
    {
        [Fact]
        public void Pago_CheckPropertiesValid()
        {
            var reservaIdTest = Guid.NewGuid();
            var importeTotalTest = 500;
            var importePagadoTest = 300;

            var obj = new Pago(reservaIdTest, importeTotalTest, importePagadoTest);

            Assert.Equal(500, obj.Importe);
            Assert.Equal(300, obj.ImportePagado);


            obj.ValidadPago(importeTotalTest, importePagadoTest);

            var totalTest = importeTotalTest - importePagadoTest;
            var tipoTest = "Factura";
            obj.ObtTipoandImporteDado(importeTotalTest, importePagadoTest, totalTest);
            obj.ConsolidarPago(reservaIdTest, importePagadoTest, tipoTest);
        }


        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (Pago)Activator.CreateInstance(typeof(Pago), true);
            Assert.Null(command.Importe);
            Assert.Null(command.ImportePagado);
            Assert.Equal(Guid.Empty, command.ReservaId);
        }


    }
}
