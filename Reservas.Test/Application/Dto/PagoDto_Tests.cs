using Reservas.Application.Dto.Pago;
using Xunit;

namespace Reservas.Test.Application.Dto
{
    public class PagoDto_Tests
    {
        [Fact]
        public void PagoDto_CheckPropertiesValid()
        {
            var importePagadoTest = 100;
            var nroReservaTest = "RES-001";
 
            var objPago = new PagoDto();

            Assert.Equal(0, objPago.ImportePagado);
            Assert.Null(objPago.NroReserva);


            objPago.ImportePagado = importePagadoTest;
            objPago.NroReserva = nroReservaTest;

            Assert.Equal(importePagadoTest, objPago.ImportePagado);
            Assert.Equal(nroReservaTest, objPago.NroReserva);
        }
    }
}
