using TicketingApp.Models;

namespace TicketingApp.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Task<Customer> GetById(int id);
    }
}
