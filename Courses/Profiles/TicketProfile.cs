using AutoMapper;
using Courses.Models;
using Courses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Profiles
{
    public class TicketProfile: Profile
    {
        public TicketProfile()
        {
            CreateMap<AddTicketsViewModel, Ticket>()
                .ForMember(
                    dest => dest.ConcertId,
                    opt => opt.MapFrom(src => src.ConcertId))
                .ForMember(
                    dest => dest.Date,
                    opt => opt.MapFrom(src => src.Date));
        }

    }
}
