using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nebb.Data.DTOs;
using Nebb.Data.Models;
using Nebb.Service.Services;

namespace Nebb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsAPIController : ControllerBase
    {
        private readonly NebbContext _context;
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
        public Task<TicketDTO> GetTicket(int id)
        {
            return _ticketService.GetTicket(id);
        }

        // PUT: api/TicketsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public TicketDTO PutTicket([FromRoute]int id, [FromBody]TicketDTO ticket)
        {
            return _ticketService.UpdateTicket(id, ticket);
        }

        // POST: api/TicketsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            _context.Ticket.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
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

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
