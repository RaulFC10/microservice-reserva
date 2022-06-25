using Reservas.Infraestructure.EF.ReadModel;
using System;
using Xunit;

namespace Reservas.Test.Infraestructure.ReadModel
{
    public class PasajeroReadModel_Tests
    {
        [Fact]
        public void PasajeroReadModel_CheckPropertiesValid()
        {
            var idTest = Guid.NewGuid();
            var ciTest = "964111";



            var obj = new PasajeroReadModel();
            Assert.Equal(Guid.Empty, obj.Id);
            Assert.Null(obj.Ci);

            obj.Id = idTest;
            obj.Ci = ciTest;



            Assert.Equal(idTest, obj.Id);
            Assert.Equal(ciTest, obj.Ci);


        }
    }
}
