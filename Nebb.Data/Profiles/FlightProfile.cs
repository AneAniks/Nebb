using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Nebb.Data.DTOs;
using Nebb.Data.Models;

namespace Nebb.Data.Profiles
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<FlightInfo, FlightInfoDTO>()
                .ReverseMap();
        }
    }
}
