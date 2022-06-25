using Microsoft.Extensions.Logging;
using Moq;
using Reservas.Application.Dto.Reserva;
using Reservas.Application.Service;
using Reservas.Application.UseCases.Command.Reservas.CrearReserva;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Application.UseCases.Handler
{
    public class CrearReservaHandler_Tests
    {
        private readonly Mock<IReservaRepository> _reservaRepository;
        private readonly Mock<IReservaService> _reservaService;
        private readonly Mock<IReservaFactory> _reservaFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<CrearReservaHandler>> _logger;

        public CrearReservaHandler_Tests()
        {
            _reservaRepository = new Mock<IReservaRepository>();
            _reservaService = new Mock<IReservaService>();
            _reservaFactory = new Mock<IReservaFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _logger = new Mock<ILogger<CrearReservaHandler>>();
        }


        [Fact]
        public void Handle_Correctly()
        {
            var vueloIdTest = Guid.NewGuid();
            var nroReservaTest = "R-001";
            var fechaVueloTest = DateTime.Now;
            var objreservaTest = new Reserva(vueloIdTest, nroReservaTest, fechaVueloTest);

            var handler = new CrearReservaHandler(_reservaRepository.Object, _logger.Object, _reservaService.Object, _reservaFactory.Object, _unitOfWork.Object);

          

            var requestTest = new CrearReservaCommand(getVueloReserva(), vueloIdTest, fechaVueloTest);

            var tcs = new CancellationTokenSource(1000);
            var re = handler.Handle(requestTest, tcs.Token);

            _reservaService.Setup(mock => mock.GenerarNroReservaAsync()).Returns(Task.FromResult(nroReservaTest));
            _reservaFactory.Setup(mock => mock.Create(vueloIdTest, nroReservaTest, fechaVueloTest)).Returns(objreservaTest);

            foreach (var item in requestTest.Detalle)
            {
                objreservaTest.AgregarItem(item.IdPasajero, item.Costo);
            }

            objreservaTest.ConsolidarReserva();
            _reservaRepository.Setup(mock => mock.CreateAsync(objreservaTest));
            _unitOfWork.Setup(mock => mock.Commit());

            Assert.Equal("R-001", objreservaTest.NroReserva);
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
