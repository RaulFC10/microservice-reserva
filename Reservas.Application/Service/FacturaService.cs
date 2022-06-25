using Reservas.Application.Service.Interface;
using System;
using System.Threading.Tasks;

namespace Reservas.Application.Service
{
    public class FacturaService : IFacturaService
    {
        public Task<string> GenerarNroFacturaAsync()
        {
            Random r = new Random();
            int digitos = r.Next(1000, 9999);

            return Task.FromResult($"F-{digitos}");
        }
    }
}
