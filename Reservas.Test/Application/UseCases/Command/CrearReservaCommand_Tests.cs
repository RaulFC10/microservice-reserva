using Reservas.Application.Dto.Reserva;
using Reservas.Application.UseCases.Command.Reservas.CrearReserva;
using System;
using System.Collections.Generic;
using Xunit;

namespace Reservas.Test.Application.UseCases.Command
{
    public class CrearReservaCommand_Tests
    {
        [Fact]
        public void IsRequest_Valid()
        {
            var detalleTest = getVueloReserva();
            var idVueloTest = Guid.NewGuid();
            var fechaVueloTest = DateTime.Now;
            var command = new CrearReservaCommand(detalleTest,idVueloTest, fechaVueloTest);

            Assert.Equal(2, command.Detalle.Count);
            Assert.Equal(idVueloTest, command.IdVuelo);
            Assert.Equal(fechaVueloTest, command.FechaVuelo);
        }

        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (CrearReservaCommand)Activator.CreateInstance(typeof(CrearReservaCommand), true);
            Assert.Equal(Guid.Empty, command.IdVuelo);
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
