using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TicketingApp.Models;
using TicketingApp.Repository;

namespace TicketingApp.Controllers
{
    [ApiController]
    [EnableCors] 
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]/GetById")]
        public async Task <ActionResult<Customer>> GetById(int id)
        {
            var tempCustomer = await _customerRepository.GetById(id);
            return Ok(tempCustomer);
        }

        [HttpGet]
        [Route("api/[controller]/GetAllCustomers")]
        public async Task <ActionResult<Customer>> GetAll()
        {
            var tempCustomers = await _customerRepository.GetAll();
            return Ok(tempCustomers);
        }
    }
}
