using MediatR;
using Reservas.Application.Service.Interface;
using Reservas.Domain.Event;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Command.Pagos.RegistrarFacturaOrReciboWhenPagoRegistrado
{
    public class RegistrarFacturaOrReciboWhenPagoRegistradoHandler : INotificationHandler<PagoRegistrado>
    {
        private readonly IFacturaFactory _facturaFactory;
        private readonly IFacturaRepository _facturaRepository;
        private readonly IFacturaService _facturaService;

        private readonly IReciboFactory _reciboFactory;
        private readonly IReciboRepository _reciboRepository;
        private readonly IReciboService _reciboService;

        private readonly IReservaRepository _reservaRepository;
        public RegistrarFacturaOrReciboWhenPagoRegistradoHandler(IFacturaFactory facturaFactory, IFacturaRepository facturaRepository, IReciboFactory reciboFactory, IReciboRepository reciboRepository, IFacturaService facturaService, IReciboService reciboService, IReservaRepository reservaRepository)
        {
            _facturaFactory = facturaFactory;
            _facturaRepository = facturaRepository;
            _reciboFactory = reciboFactory;
            _reciboRepository = reciboRepository;
            _facturaService = facturaService;
            _reciboService = reciboService;
            _reservaRepository = reservaRepository;
        }

        public async Task Handle(PagoRegistrado notification, CancellationToken cancellationToken)
        {
            try
            {
                if(notification.Tipo == "Factura")
                {
                    string nroFactura = await _facturaService.GenerarNroFacturaAsync();
                    Factura objFactura = _facturaFactory.Create(notification.PagoId, nroFactura, notification.Importe);
        
                    //objFactura.ConsolidarFactura(notification.ReservaId);
                    Reserva obj = await _reservaRepository.FindByIdAsync(notification.ReservaId);
                    obj.VentaReserva();
                    await _reservaRepository.UpdateAsync(obj);

                    await _facturaRepository.CreateAsync(objFactura);
                    
                }
                else
                {
                    string nroRecibo = await _reciboService.GenerarNroReciboAsync();
                    Recibo objRecibo = _reciboFactory.Create(notification.PagoId, nroRecibo, notification.ImporteDado, notification.ImportePagado);
                    await _reciboRepository.CreateAsync(objRecibo);
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
