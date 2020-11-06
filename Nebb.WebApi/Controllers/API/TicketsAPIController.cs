using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nebb.Data.DTOs;
using Nebb.Service.Services;

namespace Nebb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsAPIController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsAPIController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: api/TicketsAPI
        [HttpGet]
        public IEnumerable<TicketDTO> GetTicket()
        {
            return _ticketService.GetTickets();
        }

        // GET: api/TicketsAPI/5
        [HttpGet("{id}")]
        public IEnumerable<TicketDTO> GetTicket(int id)
        {
            return _ticketService.GetTicket(id);
        }

        // PUT: api/TicketsAPI/5
        [HttpPut("{id}")]
        public TicketDTO PutTicket([FromRoute]int id, [FromBody]TicketDTO ticket)
        {
            return _ticketService.UpdateTicket(id, ticket);
        }

        // POST: api/TicketsAPI
        [HttpPost]
        public IActionResult PostTicket(TicketDTO ticket)
        {
            if (ModelState.IsValid)
            {
                var result = _ticketService.SaveTicket(ticket);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/TicketsAPI/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(int id)
        {
            var deleted = _ticketService.DeleteTicket(id);
            if(deleted)
            {
                return Ok("Successfully deleted!");
            }
            return BadRequest("That ticked does not exist!");
        }
    }
}
