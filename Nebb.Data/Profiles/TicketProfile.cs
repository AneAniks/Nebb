using AutoMapper;
using Nebb.Data.DTOs;
using Nebb.Data.Models;

namespace Nebb.Data.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDTO>()
            .ReverseMap();
        }
    }
}
