using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TicketingApp.Models;
using TicketingApp.Models.Dto;
using TicketingApp.Repository;

namespace TicketingApp.Controllers
{
    [ApiController]
    [EnableCors]
    public class TicketCategoryController : ControllerBase
    {
        private readonly ITicketCategoryRepository _ticketCatecoryRepository;
        private readonly IMapper _mapper;

        public TicketCategoryController(IMapper mapper, ITicketCategoryRepository ticketCategoryRepository)
        {
            _ticketCatecoryRepository = ticketCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]/GetById")]
        public async Task<ActionResult<TicketCategoryDto>> GetById(int id)
        {
            var tempTicket = await _ticketCatecoryRepository.GetById(id);
            return Ok(tempTicket);
        }

        [HttpGet]
        [Route("api/[controller]/GetAllTickets")]
        public async Task<ActionResult<TicketCategoryDto>> GetAll()
        {
            var tempTicket = await _ticketCatecoryRepository.GetAll();
            var ticketDto = _mapper.Map<List<TicketCategoryDto>>(tempTicket);

            return Ok(ticketDto);
        }

    }
}
