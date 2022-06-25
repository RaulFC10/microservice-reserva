using Reservas.Infraestructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Infraestructure.ReadModel
{
    public class VueloReservaReadModel_Tests
    {
        [Fact]
        public void VueloReservaReadModel_CheckPropertiesValid()
        {
            var idTest = Guid.NewGuid();
            var costoTest = 500;
            var activoTest = true;
            var idPasajeroTest = Guid.NewGuid();


            var obj = new VueloReservaReadModel();
            Assert.Equal(Guid.Empty, obj.Id);
            Assert.Equal(0, obj.Costo);
            Assert.False(obj.Activo);
            Assert.Equal(Guid.Empty, obj.IdPasajero);

            obj.Id = idTest;
            obj.Costo = costoTest;
            obj.Activo = activoTest;
            obj.IdPasajero = idPasajeroTest;

            Assert.Equal(idTest, obj.Id);
            Assert.Equal(costoTest, obj.Costo);
            Assert.Equal(activoTest, obj.Activo);
            Assert.Equal(idPasajeroTest, obj.IdPasajero);
        }
    }
}
