using Reservas.Application.Service;
using Xunit;

namespace Reservas.Test.Application.Service
{
    public class FacturaService_Tests
    {
        [Theory]
        [InlineData("XYZ", false)]
        [InlineData("456", false)]
        [InlineData("789", false)]
        [InlineData("111", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public async void GenerarNroFactura_CheckValidData(string expectedNroFactura, bool isEqual)
        {
            var facturaService = new FacturaService();
            string nroFactura = await facturaService.GenerarNroFacturaAsync();
            if (isEqual)
            {
                Assert.Equal(expectedNroFactura, nroFactura);
            }
            else
            {
                Assert.NotEqual(expectedNroFactura, nroFactura);
            }
        }
    }
}
