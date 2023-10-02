using AutoMapper;
using TicketingApp.Repository;

namespace TicketingApp.Services
{
    public class EventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper  mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
    }
}
