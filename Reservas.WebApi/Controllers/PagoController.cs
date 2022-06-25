using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservas.Application.UseCases.Command.Pagos.RegistrarPago;
using System;
using System.Threading.Tasks;

namespace Reservas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PagoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegistrarPagoCommand command)
        {
            try
            {
                var (id, tipo) = await _mediator.Send(command);
                return Ok(new
                {
                    Resp = true,
                    Message = $"{tipo} Generado Correctamente"
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
