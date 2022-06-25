using Reservas.Application.UseCases.Queries.Reservas.SearchReservas;
using Xunit;

namespace Reservas.Test.Application.UseCases.Queries
{
    public class SearchReservasQuery_Tests
    {
        [Fact]
        public void SearchReservasQuery_CheckPropertiesValid()
        {
 
            var obj = new SearchReservasQuery();

            Assert.NotEqual("R-111", obj.NroReserva);
        }
    }
}
