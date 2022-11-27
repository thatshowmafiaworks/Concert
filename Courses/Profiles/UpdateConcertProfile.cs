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
    public class UpdateConcertProfile: Profile
    {
        public UpdateConcertProfile()
        {
            CreateMap<UpdateConcertViewModel, Concert>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}"))
                .ForMember(
                    dest => dest.Place,
                    opt => opt.MapFrom(src => $"{src.Place}"))
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
                    dest => dest.EventType,
                    opt => opt.MapFrom(src => $"{src.EventType}"));

        }
    }
}
