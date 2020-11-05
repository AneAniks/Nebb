using System.Collections.Generic;
using System.Threading.Tasks;
using Nebb.Data.DTOs;
using Nebb.Data.Models;

namespace Nebb.Service.Services
{
    public interface ITicketService
    {
        IEnumerable<TicketDTO> GetTickets();
        Task<TicketDTO> GetTicket(int id);
        Ticket GetTicket2(int id);
        TicketDTO SaveTicket(TicketDTO ticket);
        TicketDTO UpdateTicket(int id, TicketDTO ticket);
        bool DeleteTicket(int id);
    }
}
