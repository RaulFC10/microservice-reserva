using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservas.Application.UseCases.Command.Reservas.CrearReserva;
using Reservas.Application.UseCases.Queries.Reservas.SearchReservas;
using System;
using System.Threading.Tasks;

namespace Reservas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CrearReservaCommand command)
        {
            try
            {
                var obj = await _mediator.Send(command);

                return Ok(new
                {
                    Resp = true,
                    Message = "Reserva Registrada Correctamente",
                    Data = new
                    {
                        id = obj.Id,
                        nroReserva = (obj.NroReserva.Value).ToString(),
                        costo = (obj.Costo.Value).ToString(),
                        hora = obj.Hora.ToString(),
                        horaLimitePago = obj.HoraLimite.ToString()
                    }
                }); ; ;
            
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Resp = false,
                    Message = ex.Message
                });
            }
            
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SearchReservasQuery query)
        {
            var reservas = await _mediator.Send(query);

            if (reservas == null)
                return BadRequest();

            return Ok(reservas);
        }


 
    }
}
