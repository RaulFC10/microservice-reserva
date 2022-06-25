using Microsoft.Extensions.Logging;
using Moq;
using Reservas.Application.UseCases.Command.Anulacion.RegistrarAnulacion;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.ReservaAnulados;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using ShareKernel.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Moq.It;

namespace Reservas.Test.Application.UseCases.Handler
{
    public class RegistrarAnulacionHandler_Tests
    {
        private readonly Mock<IReservaAnuladoRepository> _anulacionRepository;
        private readonly Mock<IReservaRepository> _reservaRepository;
        private readonly Mock<ILogger<RegistrarAnulacionHandler>> _logger;
        private readonly Mock<IAnulacionFactory> _anulacionFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;



         
  
        private ReservaAnulado objAnulacionTest;

        private string descripcionTest = "reserva no pagada";
        private Guid guidTest = Guid.NewGuid();
        public RegistrarAnulacionHandler_Tests()
        {
            _anulacionRepository = new Mock<IReservaAnuladoRepository>();
            _reservaRepository = new Mock<IReservaRepository>();
            _logger = new Mock<ILogger<RegistrarAnulacionHandler>>();
            _anulacionFactory = new Mock<IAnulacionFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();

            objAnulacionTest = new AnulacionFactory().Create(descripcionTest, guidTest);
        }

        [Fact]
        public void RegistrarAnulacionHandler_Handle_Correctly()
        {
            try
            {
                var vueloIdTest = Guid.NewGuid();
                var nroReservaTest = "R-001";
                var fechaVueloTest = DateTime.Now;
                var objreservaTest = new Reserva(vueloIdTest, nroReservaTest, fechaVueloTest);



                Guid Id = Guid.Empty;
                var nroReservaRequestTest = "R-001";
                var descripcionRequestTest = "Reserva no pagado";


                _reservaRepository.Setup(reservaRepository => reservaRepository.ObtReserva(nroReservaRequestTest)).Returns(Task.FromResult(objreservaTest));


                _anulacionFactory.Setup(anulacionFactory => anulacionFactory.Create(descripcionRequestTest, objreservaTest.Id)).Returns(objAnulacionTest);


                var objHandler = new RegistrarAnulacionHandler(
                    _logger.Object,
                    _anulacionFactory.Object,
                    _unitOfWork.Object,
                    _reservaRepository.Object,
                    _anulacionRepository.Object);

                var requestTest = new RegistrarAnulacionCommand(nroReservaRequestTest, descripcionRequestTest);

                var tcs = new CancellationTokenSource(1000);
                var result = objHandler.Handle(requestTest, tcs.Token);


                _anulacionRepository.Verify(mock => mock.CreateAsync(IsAny<ReservaAnulado>()), Times.Once);
                _unitOfWork.Verify(mock => mock.Commit(), Times.Once);

                Assert.NotEqual(Guid.NewGuid(),objAnulacionTest.Id);

                Assert.IsType<Guid>(result.Result);
            }
            catch (Exception ex)
            {

                _logger.Setup(lo => lo.LogError(ex, "Error al registrar la anulacion"));
                throw new BussinessRuleValidationException(ex.Message);
            }
            


        }
    }
}
