using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketingApp.Models;

namespace TicketingApp.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();

        Task<Order> GetOrderById(int id);

        void AddAsync(Order order);

        void Update(Order order);

        void Delete(Order order);

    }
}
