using Reservas.Application.Dto.Reserva;
using System;
using System.Collections.Generic;
using Xunit;

namespace Reservas.Test.Application.Dto
{
    public class ReservaDto_Tests
    {
        [Fact]
        public void ReservaDto_CheckPropertiesValid()
        {
            var idTest = Guid.NewGuid();
            var idVueloTest = Guid.NewGuid();
            var nroReservaTest = "RES-001";
            var costoTest = 140;
            var vueloReservaTest = getVueloReserva();


            var objReserva = new ReservaDto();

            Assert.Equal(Guid.Empty, objReserva.Id);
            Assert.Equal(Guid.Empty, objReserva.IdVuelo);
            Assert.Null(objReserva.NroReserva);
            Assert.Equal(0, objReserva.Costo);
            Assert.Empty(objReserva.VueloReserva);

            objReserva.Id = idTest;
            objReserva.IdVuelo = idVueloTest;
            objReserva.NroReserva = nroReservaTest;
            objReserva.Costo = costoTest;
            objReserva.VueloReserva = vueloReservaTest;

            Assert.Equal(idTest, objReserva.Id);
            Assert.Equal(idVueloTest, objReserva.IdVuelo);
            Assert.Equal(nroReservaTest, objReserva.NroReserva);
            Assert.Equal(costoTest, objReserva.Costo);
            Assert.Equal(vueloReservaTest.Count, objReserva.VueloReserva.Count);
        }


        private List<VueloReservaDto> getVueloReserva()
        {
            return new List<VueloReservaDto>()
            {
                new()
                {
                    Costo = 500,
                    IdPasajero = Guid.NewGuid()
                },
                new()
                {
                    Costo = 500,
                    IdPasajero = Guid.NewGuid()
                }
            };
        }
    }
}
