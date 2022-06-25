using MediatR;
using Reservas.Domain.Event;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Command.Reservas.UpdateActivoWhenAnulacionAgregado
{
    public class UpdateActivoWhenAnulacionAgregadoHandler : INotificationHandler<AnulacionRegistrada>
    {
        private readonly IReservaRepository _reservaRepository;

        public UpdateActivoWhenAnulacionAgregadoHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task Handle(AnulacionRegistrada notification, CancellationToken cancellationToken)
        {
            Reserva obj =  await _reservaRepository.FindByIdAsync(notification.ReservaId);
            obj.AnularReserva();

            await _reservaRepository.UpdateAsync(obj);
        }
    }
}
