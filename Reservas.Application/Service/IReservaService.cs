using System.Threading.Tasks;

namespace Reservas.Application.Service
{
    public interface IReservaService
    {
        Task<string> GenerarNroReservaAsync();
    }
}
