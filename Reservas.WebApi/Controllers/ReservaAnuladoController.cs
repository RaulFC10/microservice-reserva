using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservas.Application.UseCases.Command.Anulacion.RegistrarAnulacion;
using System;
using System.Threading.Tasks;

namespace Reservas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaAnuladoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservaAnuladoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegistrarAnulacionCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok(new
                {
                    Resp = true,
                    Message = "Reserva Anulado Correctamente"
                });
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
    }
}
