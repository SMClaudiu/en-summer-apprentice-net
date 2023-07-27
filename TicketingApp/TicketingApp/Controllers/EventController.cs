using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingApp.Models.Dto;
using TicketingApp.Models.Dto.Patches;
using TicketingApp.Repository;

namespace TicketingApp.Controllers
{
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]/GetById")]

        public ActionResult<EventDto> GetById(int id)
        {
            var ev = _eventRepository.GetEventById(id);
            var eventDto = _mapper.Map<EventDto>(ev);
            return Ok(eventDto);
        }

        [HttpGet]
        [Route("api/[controller]/GetAll")]

        public async Task<ActionResult<List<EventDto>>> GetAll() {
            var ev =  _eventRepository.GetAll();
            var eventDto =  _mapper.Map<List<EventDto>>(ev);
            return Ok(eventDto);
        }

        [HttpDelete]
        [Route("api/[controller]/Delete")]

        public async Task<ActionResult<EventDto>> Delete(int eventId)
        {
            var eventEntity =  _eventRepository.GetEventById(eventId);
            if(eventEntity != null)
            {
                Console.WriteLine("Nu exista in db");
                _eventRepository.Delete(eventEntity);
                return NoContent();
            }
            return NotFound();
        }


        [HttpPatch]
        [Route("api/[controller]/Patch")]
        public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto epd)
        {
            if(epd != null)
            {
                var eventEntity =  _eventRepository.GetEventById(epd.EventId);
                if(eventEntity != null)
                {
                    _mapper.Map(epd, eventEntity);
                    _eventRepository.Update(eventEntity);
                }
                return NoContent();
            }
            return NotFound();
        }
    }
}
