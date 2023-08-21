using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TicketingApp.Models;
using TicketingApp.Repository;
using System.Threading.Tasks; // Add this using directive at the top
using TicketingApp.Models.Dto;

namespace TicketingApp.Controllers
{

    [ApiController]
    [EnableCors]
    public class EventTypeController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEventTypeRepository _eventTypeRepository;

        public EventTypeController(IMapper mapper, IEventTypeRepository eventTypeRepository)
        {
            _mapper = mapper;
            _eventTypeRepository = eventTypeRepository;
        }

        [HttpGet]
        [Route("api/[controller]/GetAll")]
        public async Task<ActionResult<EventTypeDto>> GetAll()
        {
                var tempEt = await _eventTypeRepository.GetAll();
                var eventTypeDto = _mapper.Map<List<EventType>>(tempEt);
                return Ok(eventTypeDto);
        }

        [HttpGet]
        [Route("api/[controller]/GetById")]
        public async Task<ActionResult<EventType>> GetById(int id)
        {
            var tempEt = await _eventTypeRepository.GetById(id);
            return Ok(tempEt);
        }
    }
}
