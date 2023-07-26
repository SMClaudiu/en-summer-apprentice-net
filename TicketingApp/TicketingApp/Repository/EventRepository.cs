using Microsoft.EntityFrameworkCore;
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
        public void Add(Event ev)
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

        public Event GetOrderById(int id)
        {
            try
            {
                var ev = _dbContext.Events.FirstOrDefault(e => e.EventId == id);
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

        public void Delete(int id)
        {
            try
            {
                var ev = GetOrderById(id);
                if (ev != null)
                {
                    _dbContext.Events.Remove(ev);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
            }
        }

        public IEnumerable<Event> GetAll()
        {
            throw new NotImplementedException();
        }



        public void Update(Event ev)
        {
            try
            {
                var tempEv = GetOrderById(ev.EventId);
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