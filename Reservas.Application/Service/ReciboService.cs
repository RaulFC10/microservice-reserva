using Reservas.Application.Service.Interface;
using System;
using System.Threading.Tasks;

namespace Reservas.Application.Service
{
    public class ReciboService : IReciboService
    {
        public Task<string> GenerarNroReciboAsync()
        {
            Random r = new Random();
            int digitos = r.Next(1000, 9999);

            return Task.FromResult($"R-{digitos}");
        }
    }
}
