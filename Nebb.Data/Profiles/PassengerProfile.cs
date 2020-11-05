using AutoMapper;
using Nebb.Data.DTOs;
using Nebb.Data.Models;

namespace Nebb.Data.Profiles
{
    public class PassengerProfile : Profile
    {
        public PassengerProfile()
        {
            CreateMap<PassengerInfo, PassengerInfoDTO>()
                .ReverseMap();
        }
    }
}
