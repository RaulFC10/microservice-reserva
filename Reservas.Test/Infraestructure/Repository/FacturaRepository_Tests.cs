using Microsoft.EntityFrameworkCore;
using Moq;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Repositories;
using Reservas.Infraestructure.EF.Contexts;
using Reservas.Infraestructure.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace Reservas.Test.Infraestructure.Repository
{
    public class FacturaRepository_Tests 
    {
        public readonly DbSet<Factura> _factura;
        public readonly Mock<WriteDbContext> context;
        public FacturaRepository_Tests()
        {
            context = new Mock<WriteDbContext>();
            _factura = context.Object.Factura;


        }


 
        /*
        private readonly Mock<IFacturaRepository> _repositoryFactura;

        public FacturaRepository_Tests()
        {
            _repositoryFactura = new Mock<IFacturaRepository>();
        }
        [Fact]
        public void FacturaCreateRepository()
        {
            var pagoIdTest = Guid.NewGuid();
            var nroFacturaTest = "F-0001";
            var importeTest = 100;
            var objreservaTest = new Factura(pagoIdTest, nroFacturaTest, importeTest);

            _repositoryFactura.Setup(mock => mock.CreateAsync(objreservaTest)).Returns(Task.FromResult(objreservaTest));

            Assert.NotNull(objreservaTest);

        }

        [Fact]
        public void FacturaFindByIdAsyncRepository()
        {
            var factoryIdTest = Guid.NewGuid();


            var pagoIdTest = Guid.NewGuid();
            var nroFacturaTest = "F-0001";
            var importeTest = 100;
            var objreservaTest = new Factura(pagoIdTest, nroFacturaTest, importeTest);

            _repositoryFactura.Setup(mock => mock.FindByIdAsync(factoryIdTest)).Returns(Task.FromResult(objreservaTest));

            Assert.NotNull(objreservaTest);

        }
        */
    }
}
