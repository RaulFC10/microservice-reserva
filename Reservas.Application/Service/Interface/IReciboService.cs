using System.Threading.Tasks;

namespace Reservas.Application.Service.Interface
{
    public interface IReciboService
    {
        Task<string> GenerarNroReciboAsync();
    }
}
