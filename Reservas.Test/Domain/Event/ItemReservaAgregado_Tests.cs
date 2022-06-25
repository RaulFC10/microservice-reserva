using Reservas.Domain.Event;
using System;
using Xunit;

namespace Reservas.Test.Domain.Event
{
    public class ItemReservaAgregado_Tests
    {
        [Fact]
        public void ItemReservaAgreago_CheckPropertiesValid()
        {
            var idPasajeroTest = Guid.NewGuid();
            var costoTest = 200;
    
            var obj = new ItemReservaAgregado(
                idPasajeroTest,
                costoTest);

            Assert.Equal(idPasajeroTest, obj.IdPasajero);
            Assert.Equal(costoTest, obj.Costo);

        }
    }
}
