using TicketingApp.Models;

namespace TicketingApp.Repository
{
    public interface IEventTypeRepository
    {
        Task<IEnumerable<EventType>> GetAll();

        Task<EventType> GetById(int id);
    }
}
