using Microsoft.Extensions.Logging;
using Moq;
using Reservas.Application.Dto.Reserva;
using Reservas.Application.UseCases.Command.Reservas.actualizarReserva;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Application.UseCases.Handler
{
    public class ActualizarReservaHandler_Tests
    {
        private readonly Mock<IReservaRepository> _reservaRepository;
        private readonly Mock<ILogger<ActualizarReservaHandler>> _logger;
        private readonly Mock<IUnitOfWork> _unitOfWork;


        public ActualizarReservaHandler_Tests()
        {
            _reservaRepository = new Mock<IReservaRepository>();
            _logger = new Mock<ILogger<ActualizarReservaHandler>>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void Handle_Correctly()
        {
            var handler = new ActualizarReservaHandler(
                _reservaRepository.Object,
                _logger.Object,
                _unitOfWork.Object
                );
            var vueloReservaTest = getVueloReserva();
            var objRequest = new ActualizarReservaCommand(vueloReservaTest);

            var tcs = new CancellationTokenSource(1000);
            var re = handler.Handle(objRequest, tcs.Token);

            var vueloIdTest = Guid.NewGuid();
            var nroReservaTest = "R-001";
            var fechaVueloTest = DateTime.Now;
            var objreservaTest = new Reserva(vueloIdTest, nroReservaTest, fechaVueloTest);

            _reservaRepository.Setup(mock => mock.FindByIdAsync(objRequest.Id)).Returns(Task.FromResult(objreservaTest));


            if(objreservaTest is null)
            {
                throw new BussinessRuleValidationException("El id no fue encontrado");
            }
            else
            {
                foreach (var item in objreservaTest.VueloReserva)
                {
                    objreservaTest.AgregarItem(item.IdPasajero, item.Costo);
                }

                _reservaRepository.Setup(mock => mock.UpdateAsync(objreservaTest));
                _unitOfWork.Setup(mock => mock.Commit());


                Assert.Equal(0, objreservaTest.VueloReserva.Count);
            }

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
