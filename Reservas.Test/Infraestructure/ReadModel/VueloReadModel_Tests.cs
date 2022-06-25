using Reservas.Infraestructure.EF.ReadModel;
using System;
using Xunit;

namespace Reservas.Test.Infraestructure.ReadModel
{
    public class VueloReadModel_Tests
    {
        [Fact]
        public void VueloReadModel_CheckPropertiesValid()
        {
            var idTest = Guid.NewGuid();
            var costoTest = 500;

            var obj = new VueloReadModel();
            Assert.Equal(Guid.Empty, obj.Id);
            Assert.Equal(0, obj.Costo);

            obj.Id = idTest;
            obj.Costo = costoTest;

            Assert.Equal(idTest, obj.Id);
            Assert.Equal(costoTest, obj.Costo);
        }

    }
}
