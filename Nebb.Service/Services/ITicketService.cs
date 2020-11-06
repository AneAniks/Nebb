using System.Collections.Generic;
using Nebb.Data.DTOs;

namespace Nebb.Service.Services
{
    public interface ITicketService
    {
        IEnumerable<TicketDTO> GetTickets();
        IEnumerable<TicketDTO> GetTicket(int id);
        TicketDTO SaveTicket(TicketDTO ticket);
        TicketDTO UpdateTicket(int id, TicketDTO ticket);
        bool DeleteTicket(int id);
    }
}
