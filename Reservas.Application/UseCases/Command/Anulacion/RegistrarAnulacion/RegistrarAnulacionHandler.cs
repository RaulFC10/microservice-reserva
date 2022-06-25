using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.ReservaAnulados;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using ShareKernel.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Command.Anulacion.RegistrarAnulacion
{
    public class RegistrarAnulacionHandler : IRequestHandler<RegistrarAnulacionCommand, Guid>
    {
        private readonly IReservaAnuladoRepository _anulacion;
        private readonly IReservaRepository _reservaRepository;
        private readonly ILogger<RegistrarAnulacionHandler> _logger;
        private readonly IAnulacionFactory _anulacionFactory;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarAnulacionHandler(ILogger<RegistrarAnulacionHandler> logger, IAnulacionFactory anulacionFactory, IUnitOfWork unitOfWork, IReservaRepository reservaRepository, IReservaAnuladoRepository anulacion)
        {
            _logger = logger;
            _anulacionFactory = anulacionFactory;
            _unitOfWork = unitOfWork;
            _reservaRepository = reservaRepository;
            _anulacion = anulacion;
        }

        public async Task<Guid> Handle(RegistrarAnulacionCommand request, CancellationToken cancellationToken)
        {
            Guid Id = Guid.Empty;
            try
            {
                Reserva objReserva = await _reservaRepository.ObtReserva(request.NroReserva);
                if (objReserva is null)
                {
                    throw new BussinessRuleValidationException("No se encontro el nroReserva");
                }


                ReservaAnulado obj = _anulacionFactory.Create(request.Descripcion, objReserva.Id);
                obj.ConsolidarAnulacion(objReserva.Id, request.Descripcion);
                await _anulacion.CreateAsync(obj);
                await _unitOfWork.Commit();
                Id = obj.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar la anulacion");
                throw new BussinessRuleValidationException(ex.Message);
            }
            return Id; 
        }
    }
}
