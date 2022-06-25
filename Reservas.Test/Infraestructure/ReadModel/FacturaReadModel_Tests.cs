using Reservas.Infraestructure.EF.ReadModel;
using System;
using Xunit;

namespace Reservas.Test.Infraestructure.ReadModel
{
    public class FacturaReadModel_Tests
    {
        [Fact]
        public void FacturaReadModel_CheckPropertiesValid()
        {
         
            var nroFacturaTest = "F-0001";
            var fechaTest = DateTime.Now;
            var importeTest = 500;
             

            var obj = new FacturaReadModel();
            Assert.Equal(Guid.Empty, obj.Id);
            Assert.Null(obj.NroFactura);
            Assert.NotEqual(DateTime.Now,obj.Fecha);
            Assert.Equal(0, obj.Importe);


          
            obj.NroFactura = nroFacturaTest;
            obj.Fecha = fechaTest;
            obj.Importe = importeTest;


           
            Assert.Equal(nroFacturaTest, obj.NroFactura);
            Assert.Equal(fechaTest, obj.Fecha);
            Assert.Equal(importeTest, obj.Importe);

        }
    }
}
