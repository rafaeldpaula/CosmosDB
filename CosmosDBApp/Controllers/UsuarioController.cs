using CosmosDBApp.Commands;
using CosmosDBApp.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Get([FromQuery] string id)
        {
            var response = await _mediator.Send(new GetUsuarioCommand() { Id = id });

            return Ok(response.Result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete([FromQuery] string id)
        {
            var response = await _mediator.Send(new DeleteUsuarioCommand() { Id = id });

            return Ok(response.Result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Insert([FromQuery] InsertUsuarioCommand insertUsuarioCommand)
        {
            var response = await _mediator.Send(insertUsuarioCommand);

            return Ok(response.Result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Insert([FromQuery] UpdateUsuarioCommand updateUsuarioCommand)
        {
            var response = await _mediator.Send(updateUsuarioCommand);

            return Ok(response.Result);
        }

    }
}
