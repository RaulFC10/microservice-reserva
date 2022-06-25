using Moq;
using Reservas.Application.Service.Interface;
using Reservas.Application.UseCases.Command.Pagos.RegistrarFacturaOrReciboWhenPagoRegistrado;
using Reservas.Domain.Event;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Application.UseCases.Handler
{
    public class RegistrarFacturaOrReciboWhenPagoRegistradoHandler_Tests
    {
        private readonly Mock<IFacturaFactory> _facturaFactory;
        private readonly Mock<IFacturaRepository> _facturaRepository;

        private readonly Mock<IFacturaService> _facturaService;
        private readonly Mock<IReciboFactory> _reciboFactory;
        private readonly Mock<IReciboRepository> _reciboRepository;
        private readonly Mock<IReciboService> _reciboService;
        private readonly Mock<IReservaRepository> _reservaRepository;


        public RegistrarFacturaOrReciboWhenPagoRegistradoHandler_Tests()
        {
            _facturaFactory = new Mock<IFacturaFactory>();
            _facturaRepository = new Mock<IFacturaRepository>();
            _facturaService = new Mock<IFacturaService>();
            _reciboFactory = new Mock<IReciboFactory>();
            _reciboRepository = new Mock<IReciboRepository>();
            _reciboService = new Mock<IReciboService>();
            _reservaRepository = new Mock<IReservaRepository>();
        }




        [Fact]
        public void Factura_Correctly()
        {
            var pagoIdTest = Guid.NewGuid();
            var reservaIdTest = Guid.NewGuid();
            var importeTest = 500;
            var importeDadoTest = 0;
            var importePagadoTest = 500;
            var tipoTest = "Factura";


            var nroFactura = "F-1111";
            var handler = new RegistrarFacturaOrReciboWhenPagoRegistradoHandler(
                _facturaFactory.Object,
                _facturaRepository.Object,
                _reciboFactory.Object,
                _reciboRepository.Object,
                _facturaService.Object,
                _reciboService.Object,
                _reservaRepository.Object
                );

            var objRequest = new PagoRegistrado(
                    pagoIdTest, reservaIdTest, importeTest, importeDadoTest, importePagadoTest, tipoTest
            );


            var tcs = new CancellationTokenSource(1000);
            var re = handler.Handle(objRequest, tcs.Token);

            if (objRequest.Tipo == "Factura")
            {
                _facturaService.Setup(mock => mock.GenerarNroFacturaAsync())
                .Returns(Task.FromResult(nroFactura));


     
                var facturaTest = new Factura(pagoIdTest, nroFactura, importeTest);


                var idVueloTest = Guid.NewGuid();
                var nroReservaTest = "R-1111";
                var fechaVueloTest = DateTime.Now;
                var reservaTest = new Reserva(idVueloTest, nroReservaTest, fechaVueloTest);

                _facturaFactory.Setup(mock => mock.Create(objRequest.Id, nroFactura, objRequest.Importe))
                .Returns(facturaTest);

                _reservaRepository.Setup(mock => mock.FindByIdAsync(objRequest.ReservaId))
                .Returns(Task.FromResult(reservaTest));

                reservaTest.VentaReserva();

                _reservaRepository.Setup(mock => mock.UpdateAsync(reservaTest));

                _facturaRepository.Setup(mock => mock.CreateAsync(facturaTest));


                Assert.Equal("F-1111", facturaTest.NroFactura);
            }  
        }




        [Fact]
        public void Recibo_Correctly()
        {
            var pagoIdTest = Guid.NewGuid();
            var reservaIdTest = Guid.NewGuid();
            var importeTest = 500;
            var importeDadoTest = 0;
            var importePagadoTest = 500;
            var tipoTest = "Recibo";


            //var nroFactura = "F-1111";
            var handler = new RegistrarFacturaOrReciboWhenPagoRegistradoHandler(
                _facturaFactory.Object,
                _facturaRepository.Object,
                _reciboFactory.Object,
                _reciboRepository.Object,
                _facturaService.Object,
                _reciboService.Object,
                _reservaRepository.Object
                );

            var objRequest = new PagoRegistrado(
                    pagoIdTest, reservaIdTest, importeTest, importeDadoTest, importePagadoTest, tipoTest
            );


            var tcs = new CancellationTokenSource(1000);
            var re = handler.Handle(objRequest, tcs.Token);

            if (objRequest.Tipo == "Recibo")
            {
                var nroReciboTest = "R-1111";

                var fechaVueloTest = DateTime.Now;
                var importeTotal = 500;
                var importePagafp = 300;

                var reciboTest = new Recibo(pagoIdTest, nroReciboTest, importeTotal, importePagafp);



                _reciboService.Setup(mock => mock.GenerarNroReciboAsync())
                .Returns(Task.FromResult(nroReciboTest));

                _reciboFactory.Setup(mock => mock.Create(objRequest.PagoId, nroReciboTest, objRequest.ImporteDado, objRequest.ImportePagado))
                .Returns(reciboTest);

                _reciboRepository.Setup(mock => mock.CreateAsync(reciboTest));

                Assert.Equal("R-1111", reciboTest.NroRecibo);
            }


        }
    }
}
