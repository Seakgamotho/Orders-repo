using Client.Command;
using Client.Models;
using Client.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<Clients>> GetClients() => await _mediator.Send(new GetClients.Query());

        [HttpGet("{id}")]

        public async Task<Clients> GetClient(int id) => await _mediator.Send(new GetClientById.Query { Id = id });

        [HttpPost]
        public async Task<ActionResult> CreateClient([FromBody] AddClient.Command command)
        {
            var createClient = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetClients), new { id = createClient },null);
        }

       [HttpDelete("{id}")]
       public async Task<ActionResult> DeleteClient(int id)
        {
            await _mediator.Send(new DeleteClient.Command{ id = id });
            return NoContent();
        }
    
    }


}
