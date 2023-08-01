using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using TicketingApp.Models;
using TicketingApp.Repository;

namespace TicketingApp.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly JavaEndavaContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new JavaEndavaContext();
        }

        public void Add(Order order)
        {
            try
            {
                var tempOrder = GetOrderById(order.OrderId);
                if (tempOrder == null)
                {
                    _dbContext.Add(order);
                    _dbContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine("The order already exists");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
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
            var tempOrders =  _dbContext.Orders.Include(o=>o.Customer);
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
                var order = await _dbContext.Orders.Include(o => o.Customer).FirstOrDefaultAsync(o => o.OrderId == id);
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
                var tempOrder = GetOrderById(order.OrderId);
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
