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

            CreateMap<Event, EventDto>().ForMember(e => e.TicketCategories, tg => tg.MapFrom(src => src.TicketCategories)).ReverseMap();
            CreateMap<Event, EventPost>().ReverseMap();
            CreateMap<Event, EventPatchDto>().ReverseMap();

            CreateMap<TicketCategory, TicketCategoryDto>().ReverseMap();

            CreateMap<Venue, VenueDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderPatchDto>().ReverseMap();
            CreateMap<Order, OrderPost>().ReverseMap();
        }
    }
}
