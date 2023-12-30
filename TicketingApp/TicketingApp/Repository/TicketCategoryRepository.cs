using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using TicketingApp.Models;
using TicketingApp.Models.Dto;
using TicketingApp.Repository;

namespace TicketingApp.Repository
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly JavaEndavaContext _context;

        public TicketCategoryRepository() {
            _context = new JavaEndavaContext();
        }
        public async Task<IEnumerable<TicketCategory>> GetAll()
        {
            try
            {
                var tempTickets = _context.TicketCategories.Include(e => e.Event);
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
                return ticket;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
                return null;
            }
        }
    }
}
