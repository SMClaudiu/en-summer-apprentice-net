using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using TicketingApp.Models;
using TicketingApp.Models.Dto;
using TicketingApp.Models.Dto.Patches;
using TicketingApp.Models.Dto.Posts;

namespace TicketingApp.Profiles
{
    public class AutoMapperProfile : Profile { 
        
        public AutoMapperProfile() { 
            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.EventType, src => src.MapFrom(src => src.EventType))
                .ForMember(e => e.TicketCategories, tg => tg.MapFrom(src => src.TicketCategories)).ReverseMap();

            CreateMap<Event, EventPost>().ReverseMap();

            CreateMap<Event, EventPatchDto>().ReverseMap();

            CreateMap<TicketCategory, TicketCategoryDto>()
                .ForMember(e=> e.Event, tg =>tg.MapFrom(src =>src.Event))
                .ReverseMap();

            CreateMap<EventType, EventTypeDto>()
                .ReverseMap();

            CreateMap<Venue, VenueDto>().ReverseMap();

            CreateMap<OrderDelete, OrderDto>().ReverseMap();

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.TicketCategory.EventId))
                .ForMember(dest => dest.eventName, opt=>opt.MapFrom(src=>src.TicketCategory.Event.Name))
                .ReverseMap();
            CreateMap<Order, OrderPatchDto>().ReverseMap();

            CreateMap<Order, OrderPost>()
                .ReverseMap();
        }
    }
}
