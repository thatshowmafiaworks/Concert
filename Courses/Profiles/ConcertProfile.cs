using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Courses.Models;
using Courses.ViewModels;

namespace Courses.Profiles
{
    public class ConcertProfile: Profile
    {
        public ConcertProfile()
        {
            CreateMap<CreateConcertViewModel, Concert>()
                .ForMember(
                    dest => dest.Title,
                    opt => opt.MapFrom(src => $"{src.Title}"))
                .ForMember(
                    dest => dest.Artist,
                    opt => opt.MapFrom(src => $"{src.Artist}"))
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => $"{src.Description}"))
                .ForMember(
                    dest => dest.SeatsNumber,
                    opt => opt.MapFrom(src => $"{src.SeatsNumber}"))
                .ForMember(
                    dest => dest.EventType,
                    opt => opt.MapFrom(src => $"{src.EventType}"));

        }
    }
}
