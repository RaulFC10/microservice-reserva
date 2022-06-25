using Reservas.Infraestructure.EF.ReadModel;
using System;
using Xunit;

namespace Reservas.Test.Infraestructure.ReadModel
{
    public class ReciboReadModel_Tests
    {
        [Fact]
        public void ReciboReadModel_CheckPropertiesValid()
        {
            var idTest = Guid.NewGuid();
            var nroReciboTest = "R-0001";
            var fechaTest = DateTime.Now;
            var importeTotalTest = 500;
            var importePagadoTest = 300;
            var saldoTest = 200;


            var obj = new ReciboReadModel();
            Assert.Equal(Guid.Empty, obj.Id);
            Assert.Null(obj.NroRecibo);
            Assert.NotEqual(DateTime.Now, obj.Fecha);
            Assert.Equal(0, obj.ImporteTotal);
            Assert.Equal(0, obj.ImportePagado);
            Assert.Equal(0, obj.Saldo);


            obj.Id = idTest;
            obj.NroRecibo = nroReciboTest;
            obj.Fecha= fechaTest;
            obj.ImporteTotal = importeTotalTest;
            obj.ImportePagado = importePagadoTest;
            obj.Saldo = saldoTest;

            Assert.Equal(idTest, obj.Id);
            Assert.Equal(nroReciboTest, obj.NroRecibo);
            Assert.Equal(fechaTest, obj.Fecha);
            Assert.Equal(importeTotalTest, obj.ImporteTotal);
            Assert.Equal(importePagadoTest, obj.ImportePagado);
            Assert.Equal(saldoTest, obj.Saldo);


        }
    }
}
