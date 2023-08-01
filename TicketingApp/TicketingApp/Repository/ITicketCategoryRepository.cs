using TicketingApp.Models;

namespace TicketingApp.Repository
{
    public interface ITicketCategoryRepository
    {
        IEnumerable<TicketCategory> GetAll();

        Task<TicketCategory> GetById(int id);

    }
}
