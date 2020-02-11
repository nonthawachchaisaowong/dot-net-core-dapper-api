using AutoMapper;
using EventTracker.Dtos;
using EventTracker.Models;

namespace EventTracker.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EventDTO, Event>();
            CreateMap<Event, EventDTO>();
        }
    }
}
