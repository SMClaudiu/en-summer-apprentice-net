using Microsoft.EntityFrameworkCore;
using TicketingApp.Models;
using System.Threading.Tasks; // Add this using directive at the top


namespace TicketingApp.Repository
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly JavaEndavaContext _context;
        
        public EventTypeRepository()
        {
            _context = new JavaEndavaContext();
        }

        public async Task<IEnumerable<EventType>> GetAll()
        {
            try
            {
                var tempEt = _context.EventTypes;
                if(tempEt == null)
                {
                    return null;
                }
                return tempEt;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
                return null;
            }
        }

        public async Task<EventType> GetById(int id)
        {
            try
            {
                var existingEt = await _context.EventTypes.Where(et => et.EventTypeId == id).FirstOrDefaultAsync();
                if(existingEt != null)
                {
                    return existingEt;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
                return null;
            }
        }
    }
}
