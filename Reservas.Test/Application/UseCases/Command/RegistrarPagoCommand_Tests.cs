using Reservas.Application.UseCases.Command.Pagos.RegistrarPago;
using System;
using Xunit;

namespace Reservas.Test.Application.UseCases.Command
{
    public class RegistrarPagoCommand_Tests
    {
        [Fact]
        public void IsRequest_Valid()
        {
            var importePagadoTest = 100;
            var nroReserva = "R-1111";
            var command = new RegistrarPagoCommand(importePagadoTest, nroReserva);

            Assert.Equal(importePagadoTest, command.ImportePagado);
            Assert.Equal(nroReserva, command.NroReserva);
        }

        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (RegistrarPagoCommand)Activator.CreateInstance(typeof(RegistrarPagoCommand), true);
            Assert.Null(command.NroReserva);
        }
    }
}
