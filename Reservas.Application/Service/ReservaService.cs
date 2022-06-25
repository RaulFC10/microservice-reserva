using System;
using System.Threading.Tasks;

namespace Reservas.Application.Service
{
    public class ReservaService : IReservaService
    {
        public Task<string> GenerarNroReservaAsync()
        {
            Random r = new Random();
            int digitos =  r.Next(1000, 9999);

            return Task.FromResult($"R-{digitos}");
            //return Task.FromResult($"R-001");
        }
    }
}
