using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using TicketingApp.Models;
using TicketingApp.Models.Dto;
using TicketingApp.Repository;

namespace TicketingApp.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly JavaEndavaContext _dbContext;
        private object _ticketCategoryRepository;
        private object _customerRepository;

        public OrderRepository(ITicketCategoryRepository ticketCategoryRepository, ICustomerRepository customerRepository)
        {
            _dbContext = new JavaEndavaContext();
            //_ticketCategoryRepository = ticketCategoryRepository;
            //_customerRepository = customerRepository;
        }

        public void AddAsync (Order order)
        {   
            if(order.CustomerId != null) { 
             _dbContext.Orders.Add(order);  
             _dbContext.SaveChanges();
            }
        }

        public void Delete(Order order)
        {
            try
            {
                if (GetOrderById(order.OrderId) != null)
                {
                    _dbContext.Orders.Remove(order);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
            }
        }

        public  IEnumerable<Order> GetAll()
        {

            var tempOrders =  _dbContext.Orders.Include(o=>o.Customer).Include(o => o.TicketCategory).ThenInclude(e=>e.Event).Include(o=>o.TicketCategory);
            if(tempOrders != null)
            {
                return tempOrders;
            }
            return null;
        }   

        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                var order = await _dbContext.Orders.Include(o => o.Customer).Include(o => o.TicketCategory).ThenInclude(e => e.Event).Include(o => o.TicketCategory).FirstOrDefaultAsync(o => o.OrderId == id);
                if (order != null)
                {
                    return order;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
                return null;
            }

        }

        public async void Update(Order order)
        {
            try
            {
                //_dbContext.Update(order); care e diferenta
                var tempOrder = await GetOrderById(order.OrderId);
                if (tempOrder != null)
                {
                    _dbContext.Entry(tempOrder).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
            }
        }
    }
}
