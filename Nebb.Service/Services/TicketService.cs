using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nebb.Data.DTOs;
using Nebb.Data.Models;

namespace Nebb.Service.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;
        private readonly NebbContext _nebbContext;
        
        public TicketService(NebbContext nebbContext, IMapper mapper)
        {
            _nebbContext = nebbContext;
            _mapper = mapper;
        }
        public IEnumerable<TicketDTO> GetTickets()
        {
            return _nebbContext.Ticket
                 .Include(t => t.Passenger)
                // .Include(t => t.Flight)
                 .AsEnumerable()
                 .Select(t => new TicketDTO()
                 {
                     FlightId = t.FlightId,
                     FreeCarry = t.FreeCarry,
                     CheckedIn = t.CheckedIn,
                     Passenger = new PassengerInfoDTO()
                     {
                         FirstName = t.Passenger.FirstName,
                         LastName = t.Passenger.LastName,
                         Passport = t.Passenger.Passport,
                         LoyalMemberId = t.Passenger.LoyalMemberId,
                         UseLoyalMember = t.Passenger.UseLoyalMember
                     }
                 }).ToList();
            //.Select(t => new TicketDTO()
            // {
            //     Id = t.Id,
            //     Flight = new FlightInfoDTO()
            //     {
            //         Id = t.Flight.Id,
            //         Origin = t.Flight.Origin,
            //         Destination = t.Flight.Destination,
            //         Departure = t.Flight.Departure,
            //         ReturnDay = t.Flight.ReturnDay
            //     },
            // }).ToList();
        }
        public IEnumerable<TicketDTO> GetTicket(int id)
        {
            var ticket = _nebbContext.Ticket.Where(x => x.Id == id);
            return _mapper.Map<IEnumerable<TicketDTO>>(ticket);
        }

        public TicketDTO SaveTicket(TicketDTO ticket)
        {
            Ticket newTicket = _mapper.Map<Ticket>(ticket);

            _nebbContext.Ticket.Add(newTicket);
            _nebbContext.SaveChanges();

            return _mapper.Map<TicketDTO>(newTicket);
        }

        public TicketDTO UpdateTicket(int id, TicketDTO ticketObject)
        {
            var ticket = _nebbContext.Ticket.FirstOrDefault(x => x.Id == id);
            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }

            ticketObject.Id = id;
            ticket = _mapper.Map<Ticket>(ticketObject);
            _nebbContext.SaveChanges();

            return _mapper.Map<TicketDTO>(ticket);
        }

        public bool DeleteTicket(int id)
        {
            var ticket = _nebbContext.Ticket.FirstOrDefault(x => x.Id == id);

            if (ticket == null)
            {
                return false;
            }

            _nebbContext.Ticket.Remove(ticket);
            _nebbContext.SaveChanges();
            return true;
        }
    }
}
