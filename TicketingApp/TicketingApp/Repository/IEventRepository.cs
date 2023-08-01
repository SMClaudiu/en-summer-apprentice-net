using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketingApp.Models;
using TicketingApp.Models.Dto;
using TicketingApp.Models.Dto.Posts;

namespace TicketingApp.Repository
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Event GetEventById(int id);

        void Add(Event ev);
        void Update(Event ev);
        void Delete(Event ev);        
    }
}
