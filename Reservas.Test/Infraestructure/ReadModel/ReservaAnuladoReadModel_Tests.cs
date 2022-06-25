using Reservas.Infraestructure.EF.ReadModel;
using System;
using Xunit;

namespace Reservas.Test.Infraestructure.ReadModel
{
    public class ReservaAnuladoReadModel_Tests
    {
        [Fact]
        public void ReservaAnuladoReadModel_CheckPropertiesValid()
        {
            var idTest = Guid.NewGuid();
            var fechaTest = DateTime.Now;
            var descripcionTest = "reserva no pagada";
   


            var obj = new ReservaAnuladoReadModel();
            Assert.Equal(Guid.Empty, obj.Id);
            Assert.NotEqual(DateTime.Now, obj.Fecha);
            Assert.Null(obj.Descripcion);



            obj.Id = idTest;
            obj.Fecha = fechaTest;
            obj.Descripcion = descripcionTest;


            Assert.Equal(idTest, obj.Id);
            Assert.Equal(fechaTest, obj.Fecha);
            Assert.Equal(descripcionTest, obj.Descripcion);
        }
    }
}
