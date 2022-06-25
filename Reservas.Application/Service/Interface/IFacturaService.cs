using System.Threading.Tasks;

namespace Reservas.Application.Service.Interface
{
    public interface IFacturaService
    {
        Task<string> GenerarNroFacturaAsync();
    }
}
