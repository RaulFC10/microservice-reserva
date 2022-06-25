using Reservas.Application.Service;
using Xunit;


namespace Reservas.Test.Application.Service
{
    public class ReciboService_Tests
    {
        [Theory]
        [InlineData("XYZ", false)]
        [InlineData("456", false)]
        [InlineData("789", false)]
        [InlineData("111", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public async void GenerarNroRecibo_CheckValidData(string expectedNroRecibo, bool isEqual)
        {
            var reciboService = new ReciboService();
            string nroRecibo = await reciboService.GenerarNroReciboAsync();
            if (isEqual)
            {
                Assert.Equal(expectedNroRecibo, nroRecibo);
            }
            else
            {
                Assert.NotEqual(expectedNroRecibo, nroRecibo);
            }
        }
    }
}
