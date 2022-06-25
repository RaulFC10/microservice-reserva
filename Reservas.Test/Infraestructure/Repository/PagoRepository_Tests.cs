using Moq;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Infraestructure.Repository
{
    public class PagoRepository_Tests
    {
        private readonly Mock<IPagoRepository> _repositoryPago;

        public PagoRepository_Tests()
        {
            _repositoryPago =new Mock<IPagoRepository>();
        }

        [Fact]
        public void pagoRepository()
        {
            var reservaIdTest = Guid.NewGuid();
            var importeTest = 500;
            var importePagadoTest = 200;

            var objPagoTest = new Pago(reservaIdTest, importeTest, importePagadoTest);

            _repositoryPago.Setup(mock => mock.CreateAsync(objPagoTest)).Returns(Task.FromResult(objPagoTest));

            Assert.NotNull(objPagoTest);

        }

        [Fact]
        public void pagoCreateRepository()
        {
            var reservaIdTest = Guid.NewGuid();
            var importeTest = 500;
            var importePagadoTest = 200;

            var objPagoTest = new Pago(reservaIdTest, importeTest, importePagadoTest);

            _repositoryPago.Setup(mock => mock.CreateAsync(objPagoTest)).Returns(Task.FromResult(objPagoTest));

            Assert.NotNull(objPagoTest);

        }

        [Fact]
        public void ObtTotalImporte()
        {
            var reservaIdTest = Guid.NewGuid();
            var importePagadoTest = 400;

            _repositoryPago.Setup(mock => mock.ObtTotalImporte(reservaIdTest)).Returns(importePagadoTest);

            Assert.Equal(400,importePagadoTest);

        }

    }
}
