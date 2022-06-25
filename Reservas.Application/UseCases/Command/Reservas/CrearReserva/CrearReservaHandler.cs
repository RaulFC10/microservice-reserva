using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Application.Service;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using ShareKernel.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Command.Reservas.CrearReserva
{
    public class CrearReservaHandler : IRequestHandler<CrearReservaCommand, Reserva>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly ILogger<CrearReservaHandler> _logger;
        private readonly IReservaService _reservaService;
        private readonly IReservaFactory _reservaFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearReservaHandler(IReservaRepository reservaRepository, ILogger<CrearReservaHandler> logger, IReservaService reservaService, IReservaFactory reservaFactory = null, IUnitOfWork unitOfWork = null)
        {
            _reservaRepository = reservaRepository;
            _logger = logger;
            _reservaService = reservaService;
            _reservaFactory = reservaFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Reserva> Handle(CrearReservaCommand request, CancellationToken cancellationToken)
        {
                string nroReserva = await _reservaService.GenerarNroReservaAsync();
                Reserva objReserva = _reservaFactory.Create(request.IdVuelo, nroReserva, request.FechaVuelo);
            try
            {
                foreach (var item in request.Detalle)
                {
                    objReserva.AgregarItem(item.IdPasajero,item.Costo);
                }
                objReserva.ConsolidarReserva();

                await _reservaRepository.CreateAsync(objReserva);
                await _unitOfWork.Commit();

             }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la reserva");
                throw new BussinessRuleValidationException(ex.Message);
            }
            return objReserva;
        }
    }
}
