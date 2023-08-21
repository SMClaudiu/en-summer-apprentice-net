using TicketingApp.Models;

namespace TicketingApp.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();

        Task<Customer> GetById(int id);
    }
}
