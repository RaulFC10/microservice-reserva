using Microsoft.Extensions.Logging;
using Moq;
using Reservas.Application.UseCases.Command.Pagos.RegistrarPago;
using Reservas.Domain.Event;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Moq.It;

namespace Reservas.Test.Application.UseCases.Handler
{
    public class RegistrarPagoHandler_Tests
    {
        private readonly Mock<IPagoRepository> _pagoRepository;
        private readonly Mock<IReservaRepository> _reservaRepository;
        private readonly Mock<ILogger<RegistrarPagoHandler>> _logger;
        private readonly Mock<IPagoFactory> _pagoFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        private Guid reservaId = Guid.NewGuid();
        private string nroReservaTest = "R-1111";
        private decimal importeTest = 500;
        private decimal importePagadoTest = 250;

        private decimal totalTest = 500;
        private Pago pagoTest;

        private Guid idVueloTest = Guid.NewGuid();
        private DateTime fechaVueloTest = DateTime.Now;
        private Reserva reservaTest;
        public RegistrarPagoHandler_Tests()
        {
            _pagoRepository = new Mock<IPagoRepository>();
            _reservaRepository = new Mock<IReservaRepository>();
            _logger = new Mock<ILogger<RegistrarPagoHandler>>();
            _pagoFactory = new Mock<IPagoFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
           
            pagoTest = new PagoFactory().Create(reservaId, importeTest, importePagadoTest);
            reservaTest = new ReservaFactory().Create(idVueloTest, nroReservaTest, fechaVueloTest);
        }

        [Fact]
        public void Handle_Correctly()
        {
 
            var requestTest = new RegistrarPagoCommand(importePagadoTest, nroReservaTest);

            var objHandler = new RegistrarPagoHandler(
                _pagoRepository.Object,
                _reservaRepository.Object,
                _logger.Object,
                _pagoFactory.Object,
                _unitOfWork.Object
                );

            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(requestTest, tcs.Token);



            _reservaRepository.Setup(res => res.ObtReserva(nroReservaTest)).Returns(Task.FromResult(reservaTest));
          
            _pagoRepository.Setup(pag => pag.ObtTotalImporte(reservaTest.Id)).Returns(totalTest);
            _pagoFactory.Setup(pag => pag.Create(reservaId, importeTest, importePagadoTest)).Returns(pagoTest);

            var (tipo, importeDado) =  pagoTest.ObtTipoandImporteDado(reservaTest.Costo, requestTest.ImportePagado, totalTest);

            _pagoRepository.Setup(mock => mock.CreateAsync(pagoTest));
            
            _unitOfWork.Setup(mock => mock.Commit());

         
            Assert.Equal(500, pagoTest.Importe);
        }
    }
}
