using Reservas.Application.Dto.Reserva;
using System;
using Xunit;

namespace Reservas.Test.Application.Dto
{
    public class VueloReservaDto_Tests
    {
        [Fact]
        public void DetallePedidoDto_CheckPropertiesValid()
        {
            var idPasajeroTest = Guid.NewGuid();
            decimal costoTest = new(450.0);

            var vueloReserva = new VueloReservaDto();

            Assert.Equal(Guid.Empty, vueloReserva.IdPasajero);
            Assert.Equal(new decimal(0.0), vueloReserva.Costo);

            vueloReserva.IdPasajero = idPasajeroTest;
            vueloReserva.Costo = costoTest;


            Assert.Equal(idPasajeroTest, vueloReserva.IdPasajero);
            Assert.Equal(costoTest, vueloReserva.Costo);
        }

    }
}
