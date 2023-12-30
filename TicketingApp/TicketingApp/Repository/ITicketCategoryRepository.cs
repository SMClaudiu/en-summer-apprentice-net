using TicketingApp.Models;
using TicketingApp.Models.Dto;

namespace TicketingApp.Repository
{
    public interface ITicketCategoryRepository
    {
        Task<IEnumerable<TicketCategory>> GetAll();

        Task<TicketCategory> GetById(int id);

    }
}
