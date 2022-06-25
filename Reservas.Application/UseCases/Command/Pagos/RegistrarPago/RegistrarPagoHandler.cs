using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using ShareKernel.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Reservas.Application.UseCases.Command.Pagos.RegistrarPago
{
    public class RegistrarPagoHandler : IRequestHandler<RegistrarPagoCommand, (Guid,string)>
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IReservaRepository _reservaRepository;
        private readonly ILogger<RegistrarPagoHandler> _logger;
        private readonly IPagoFactory _pagoFactory;
        private readonly IUnitOfWork _unitOfWork;


        public RegistrarPagoHandler(IPagoRepository pagoRepository, IReservaRepository reservaRepository, ILogger<RegistrarPagoHandler> logger, IPagoFactory pagoFactory, IUnitOfWork unitOfWork)
        {
            _pagoRepository = pagoRepository;
            _reservaRepository = reservaRepository;
            _logger = logger;
            _pagoFactory = pagoFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<(Guid,string)> Handle(RegistrarPagoCommand request, CancellationToken cancellationToken)
        {
            Guid idPag = Guid.Empty;
            string Tipo = "";
            try
            {

                Reserva objReserva = await _reservaRepository.ObtReserva(request.NroReserva);
                if (objReserva is null)
                {
                    throw new BussinessRuleValidationException("No se encontro el nroReserva");
                }

                decimal total =  _pagoRepository.ObtTotalImporte(objReserva.Id);

                Pago objPago = _pagoFactory.Create(objReserva.Id, objReserva.Costo, request.ImportePagado);
                var(tipo, importeDado) = objPago.ObtTipoandImporteDado(objReserva.Costo, request.ImportePagado, total);
                objPago.ConsolidarPago(objReserva.Id, importeDado, tipo);
                await _pagoRepository.CreateAsync(objPago);
                await _unitOfWork.guardar();


                await _unitOfWork.Commit();
                Tipo = tipo;
                idPag = objPago.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar pago");
                throw new BussinessRuleValidationException(ex.Message);
            }
            return (idPag,Tipo);

        }
    }
}
