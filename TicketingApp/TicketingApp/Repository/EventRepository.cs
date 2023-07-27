using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using TicketingApp.Models;

namespace TicketingApp.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly JavaEndavaContext _dbContext;

        public EventRepository()
        {
            _dbContext = new JavaEndavaContext();

        }
        public async void Add(Event ev)
        {
            try
            {
                _dbContext.Events.Add(ev);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
            }
        }

        public IEnumerable<Event> GetAll()
        {
            var ev = _dbContext.Events.Include(e => e.Venue).Include(et => et.EventType).Include(tc => tc.TicketCategories);

            if(ev != null)
            {
                return ev;
            }
            return null;
        }

        public Event GetEventById(int id)
        {
            try
            {
                var ev =  _dbContext.Events.Include(e => e.TicketCategories).FirstOrDefault(e => e.EventId == id);
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

        public void Delete(Event ev)
        {
            if(GetEventById(ev.EventId) != null) {
                Console.WriteLine("Nu exista in db");

                _dbContext.Remove(ev);
                _dbContext.SaveChanges(true);
            }
        }



        public void Update(Event ev)
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