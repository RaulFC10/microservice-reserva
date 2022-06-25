using Moq;
using Reservas.Application.UseCases.Command.Reservas.UpdateActivoWhenAnulacionAgregado;
using Reservas.Domain.Event;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Application.UseCases.Handler
{
    public class UpdateActivoWhenAnulacionAgregadoHandler_Tests
    {
        private readonly Mock<IReservaRepository> _reservaRepository;

        public UpdateActivoWhenAnulacionAgregadoHandler_Tests()
        {
            _reservaRepository = new Mock<IReservaRepository>();
        }

        [Fact]
        public void Handle_Correctly()
        {
            var anulacionIdTest = Guid.NewGuid();
            var reservaIdTest = Guid.NewGuid();
            var descripcion = "Deposito no cancelado";


            var vueloIdTest = Guid.NewGuid();
            var nroReservaTest = "R-001";
            var fechaVueloTest = DateTime.Now;
            var reservaTest = new Reserva(vueloIdTest, nroReservaTest, fechaVueloTest);


            _reservaRepository.Setup(mock => mock.FindByIdAsync(reservaIdTest))
                .Returns(Task.FromResult(reservaTest));


            var handler = new UpdateActivoWhenAnulacionAgregadoHandler(_reservaRepository.Object);

            var objRequest = new AnulacionRegistrada(
                    anulacionIdTest, reservaIdTest, descripcion
            );
            var tcs = new CancellationTokenSource(1000);
            var re = handler.Handle(objRequest, tcs.Token);
            reservaTest.AnularReserva();

            Assert.Equal('A', reservaTest.Estado);
            Assert.False(reservaTest.Activo);

        }
    }
}
