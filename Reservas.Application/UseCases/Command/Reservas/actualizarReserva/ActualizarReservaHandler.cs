using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Domain.Repositories;
using ShareKernel.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Command.Reservas.actualizarReserva
{
    public class ActualizarReservaHandler : IRequestHandler<ActualizarReservaCommand, Guid>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly ILogger<ActualizarReservaHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarReservaHandler(IReservaRepository reservaRepository, ILogger<ActualizarReservaHandler> logger, IUnitOfWork unitOfWork)
        {
            _reservaRepository = reservaRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(ActualizarReservaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var objReserva = await _reservaRepository.FindByIdAsync(request.Id);

                if (objReserva is null)
                {
                    throw new BussinessRuleValidationException("El id no fue encontrado");
                }
                else
                {
                    foreach (var item in request.Detalle)
                    {
                        objReserva.AgregarItem(item.IdPasajero, item.Costo);
                    }
                    objReserva.ConsolidarReserva();

                    await _reservaRepository.UpdateAsync(objReserva);
                    await _unitOfWork.Commit();
                }
                
                return objReserva.Id;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la reserva");
            }
            return request.Id;
        }
    }
}
