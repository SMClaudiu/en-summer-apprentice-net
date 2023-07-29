using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingApp.Models.Dto;
using TicketingApp.Models.Dto.Patches;
using TicketingApp.Repository;

namespace TicketingApp.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]/GetOrderById")]

        public ActionResult<OrderDto> GetById(int id)
        {
            var tempOrder = _orderRepository.GetOrderById(id);
            var orderDto = _mapper.Map<OrderDto>(tempOrder); ;
            return Ok(orderDto);
        }

        [HttpGet]
        [Route("api/[controller]/GetAllEvents")]

        public ActionResult<List<OrderDto>> GetAll()
        {
            var list = _orderRepository.GetAll();
            var dtoList = _mapper.Map<List<OrderDto>>(list);
            return Ok(dtoList);
        }

        [HttpDelete]
        [Route("api/[controller]/Delete")]
        public ActionResult<OrderDto> Delete(int id)
        {
            var orderEntity = _orderRepository.GetOrderById(id);
            if (orderEntity != null)
            {
                _orderRepository.Delete(orderEntity);
                return NoContent(); 
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("api/[controller]/OrderPatch")]

        public ActionResult<OrderPatchDto> Patch(OrderPatchDto opd)
        {
            if(opd != null)
            {
                var orderEntity = _orderRepository.GetOrderById(opd.OrderId);
                if (orderEntity != null)
                {
                    _mapper.Map(opd, orderEntity);
                    _orderRepository.Update(orderEntity);
                }
                return NoContent();
            }
            return NotFound();
        }
    }   
}
