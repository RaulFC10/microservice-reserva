using Reservas.Infraestructure.EF.ReadModel;
using System;
using Xunit;

namespace Reservas.Test.Infraestructure.ReadModel
{
    public class PagoReadModel_Tests
    {
        [Fact]
        public void PagoReadModel_CheckPropertiesValid()
        {
            var idTest = Guid.NewGuid();
            var fechaTest = DateTime.Now;
            var importeTest = 500;
            var importePagadoTest = 300;



            var obj = new PagoReadModel();
            Assert.Equal(Guid.Empty, obj.Id);
            Assert.NotEqual(DateTime.Now, obj.Fecha);
            Assert.Equal(0, obj.Importe);
            Assert.Equal(0, obj.ImportePagado);




            obj.Id = idTest;
            obj.Fecha = fechaTest;
            obj.Importe = importeTest;
            obj.ImportePagado = importePagadoTest;



            Assert.Equal(idTest, obj.Id);
            Assert.Equal(fechaTest, obj.Fecha);
            Assert.Equal(importeTest, obj.Importe);
            Assert.Equal(importePagadoTest, obj.ImportePagado);

        }
    }
}
