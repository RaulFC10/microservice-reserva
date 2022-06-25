using Reservas.Application.Dto.Reserva;
using Reservas.Application.UseCases.Command.Reservas.actualizarReserva;
using System;
using System.Collections.Generic;
using Xunit;

namespace Reservas.Test.Application.UseCases.Command
{
    public class ActualizarReservaCommand_Tests
    {
        [Fact]
        public void IsRequest_Valid()
        {
            var detalleTest = getVueloReserva();
            var command = new ActualizarReservaCommand(detalleTest);

            Assert.Equal(2, command.Detalle.Count);
        }

        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (ActualizarReservaCommand)Activator.CreateInstance(typeof(ActualizarReservaCommand), true);
            Assert.Equal(Guid.Empty, command.Id);
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
