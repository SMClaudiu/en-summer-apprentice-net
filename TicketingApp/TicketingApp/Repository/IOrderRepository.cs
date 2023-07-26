using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketingApp.Models;

namespace TicketingApp.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();

        Order GetOrderById(int id);

        void Add(Order order);

        void Update(Order order);

        void Delete(int id);

    }
}
