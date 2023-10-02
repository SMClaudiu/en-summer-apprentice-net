using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, ITicketCategoryRepository ticketCategoryRepository, ICustomerRepository customerRepository, IMapper mapper)
        {

            _orderRepository = orderRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]/GetOrderById")]

        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var tempOrder = await _orderRepository.GetOrderById(id);
            var orderDto = _mapper.Map<OrderDto>(tempOrder); ;
            return Ok(orderDto);
        }

        [HttpGet]
        [Route("api/[controller]/GetAllOrders")]

        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {
            var list = _orderRepository.GetAll();
            var dtoList = _mapper.Map<List<OrderDto>>(list);
            return Ok(dtoList);
        }

        [HttpDelete]
        [Route("api/[controller]/Delete")]
        public async Task<ActionResult<OrderDelete>> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetOrderById(id);
            if (orderEntity != null)
            {
                _orderRepository.Delete(orderEntity);
                return NoContent(); 
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("api/[controller]/OrderPatch")]

        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto opd)
        {
            if(opd != null)
            {
                TicketCategory ticketCategory = await _ticketCategoryRepository.GetById(opd.TicketCategoryId);
                var orderEntity =  await _orderRepository.GetOrderById(opd.OrderId);                
                if (ticketCategory == null || orderEntity == null)
                {
                    return NotFound();
                }
                var totalPrice = opd.NumberOfTickets * ticketCategory.Price;

                orderEntity.TotalPrice = totalPrice;
                orderEntity.OrderedAt = System.DateTime.Now;
                _mapper.Map(opd, orderEntity);
                _orderRepository.Update(orderEntity);
                return Ok(orderEntity);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/[controller]/OrderPost")]

        public async Task<ActionResult<OrderPost>> Post(OrderPost op)
        {
            TicketCategory ticketCategory = await _ticketCategoryRepository.GetById(op.ticketCategoryId);
            Customer customer = await _customerRepository.GetById(op.CustomerId);
            if (ticketCategory == null || customer == null)
            {
                return NotFound();
            }
            double totalPrice = op.numberOfTickets * ticketCategory.Price;

            if (totalPrice == null)
            {
                return NotFound();
            }

            var tempOrder = _mapper.Map<Order>(op);
            tempOrder.TotalPrice = totalPrice; 
            _orderRepository.AddAsync(tempOrder);

            return Ok(tempOrder);

        }
    }   
}
