using Reservas.Application.UseCases.Command.Anulacion.RegistrarAnulacion;
using System;
using Xunit;

namespace Reservas.Test.Application.UseCases.Command
{
    public class RegistrarAnulacionCommand_Tests
    {
        [Fact]
        public void IsRequest_Valid()
        {
            var nroReservaTest = "R-001";
            var descripcionTest = "reserva no pagada";
            var command = new RegistrarAnulacionCommand(nroReservaTest, descripcionTest);

            Assert.Equal("reserva no pagada", command.Descripcion);
        }

        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (RegistrarAnulacionCommand)Activator.CreateInstance(typeof(RegistrarAnulacionCommand), true);
            Assert.Null(command.NroReserva);
        }
    }
}
