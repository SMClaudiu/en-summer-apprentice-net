using Microsoft.EntityFrameworkCore;
using TicketingApp.Models;
using TicketingApp.Repository;

namespace TicketingApp.Repository
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly JavaEndavaContext _context;

        public TicketCategoryRepository() {
            _context = new JavaEndavaContext();
        }
        public IEnumerable<TicketCategory> GetAll()
        {
            try
            {
                var tempTickets = _context.TicketCategories;
                if (tempTickets != null)
                {
                    return tempTickets;
                }
                return null;
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message + Environment.NewLine);
                return null;
            }
        }

        public async Task<TicketCategory> GetById(int id)
        {
            try
            {
                var ticket = await _context.TicketCategories.Where(tc => tc.TicketCategoryId == id).FirstOrDefaultAsync();
                if (ticket != null)
                {
                    return ticket;
                }
                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
                return null;
            }
        }
    }
}
