using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using TicketingApp.Models;
using TicketingApp.Models.Dto.Posts;
using TicketingApp.Repository;

namespace TicketingApp.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly JavaEndavaContext _dbContext;

        public EventRepository()
        {
            _dbContext = new JavaEndavaContext();

        }
        public void Add(Event ev)
        {
            try
            {
                var tempEv = GetEventById(ev.EventId);
                if(tempEv == null)
                {
                    _dbContext.Events.Add(ev);
                    _dbContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine("The event already exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
            }
        }

        public IEnumerable<Event> GetAll()
        {
            var ev = _dbContext.Events.Include(e => e.Venue).Include(et => et.EventType).Include(tc=> tc.TicketCategories);

            if (ev != null)
            {
                return ev;
            }
            return null;
        }

        public Event GetEventById(int id)
        {
            try
            {
                var ev =  _dbContext.Events.Include(e=> e.Venue).Include(et=> et.EventType).Include(tc => tc.TicketCategories).FirstOrDefault(e => e.EventId == id);
                if (ev != null)
                {
                    return ev;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
                return null;
            }
        }

        public async void Delete(Event ev)
        {
            if(GetEventById(ev.EventId) != null) {
                _dbContext.Remove(ev);
                _dbContext.SaveChanges(true);
            }
        }

        public async void Update(Event ev)
        {
            try
            {
                var tempEv = GetEventById(ev.EventId);
                if (tempEv != null)
                {
                    _dbContext.Entry(tempEv).State = EntityState.Modified;
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