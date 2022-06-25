using Reservas.Domain.Factories;
using System;
using Xunit;

namespace Reservas.Test.Domain.Factories
{
    public class ReservaFactory_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            var idVueloTest = Guid.NewGuid();
            var nroReservaTest = "R-1111";
            var fechaVueloTest = DateTime.Now;

            var factory = new ReservaFactory();
            var reserva = factory.Create(idVueloTest, nroReservaTest, fechaVueloTest);

            Assert.NotNull(reserva);
            Assert.Equal(nroReservaTest, reserva.NroReserva);
            Assert.True(reserva.Activo);

        }
    }
}
