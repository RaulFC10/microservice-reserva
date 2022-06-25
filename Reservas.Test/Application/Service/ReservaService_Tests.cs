using Reservas.Application.Service;
using Xunit;

namespace Reservas.Test.Application.Service
{
    public class ReservaService_Tests
    {
        [Theory]
        [InlineData("R-001", false)]
        [InlineData("123", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public async void GenerarReserva_CheckValidData(string expectedNroReserva, bool isEqual)
        {
            var reservaService = new ReservaService();
            string nroReserva = await reservaService.GenerarNroReservaAsync();
            if (isEqual)
            {
                Assert.Equal(expectedNroReserva, nroReserva);
            }
            else
            {
                Assert.NotEqual(expectedNroReserva, nroReserva);
            }
        }
    }
}
