using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TicketingApp.Models;
using TicketingApp.Models.Dto;
using TicketingApp.Models.Dto.Patches;
using TicketingApp.Models.Dto.Posts;
using TicketingApp.Repository;

namespace TicketingApp.Controllers
{   
    [ApiController]
    [EnableCors]
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
        [Route("api/[controller]/GetEventById")]

        public async Task<ActionResult<EventDto>> GetById(int id)
        {
            var ev = _eventRepository.GetEventById(id);
            var eventDto = _mapper.Map<EventDto>(ev);
            return Ok(eventDto);
        }

        [HttpGet]
        [Route("api/[controller]/GetAllEvents")]

        public async Task<ActionResult<List<EventDto>>> GetAll() {
            var ev =  _eventRepository.GetAll();
            var eventDto =  _mapper.Map<List<EventDto>>(ev);
            return Ok(eventDto);
        }

        [HttpDelete]
        [Route("api/[controller]/Delete")]

        public ActionResult<EventDto> Delete(int eventId)
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
        [Route("api/[controller]/EventPatch")]
        public ActionResult<EventPatchDto> Patch(EventPatchDto epd)
        {
            if(epd != null)
            {
                var eventEntity =   _eventRepository.GetEventById(epd.EventId);
                if(eventEntity != null)
                {
                    _mapper.Map(epd, eventEntity);
                    _eventRepository.Update(eventEntity);
                }
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/[controller]/EventPost")]
        public async Task<ActionResult<EventPost>> Post(EventPost ev)
        {

            try
            {
                var eventEntity = _mapper.Map<Event>(ev);

                _eventRepository.Add(eventEntity);

                var eventDto = _mapper.Map<EventPost>(eventEntity);

                return CreatedAtAction(nameof(EventController.GetById), new { id = eventDto.EventId }, eventDto);
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                return BadRequest(ModelState);
            }
        }
        

    }
}
