using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using TicketingApp.Models;
using TicketingApp.Models.Dto;
using TicketingApp.Models.Dto.Patches;

namespace TicketingApp.Profiles
{
    public class AutoMapperProfile : Profile { 
        
        public AutoMapperProfile() { 
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Event, EventDto>().ForMember(e=> e.TicketCategories, tg => tg.MapFrom(src => src.TicketCategories)).ReverseMap();
            CreateMap<Event, EventPatchDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<TicketCategory, TicketCategoryDto>().ReverseMap();
            CreateMap<Venue, VenueDto>().ReverseMap();
        }
    }
}
