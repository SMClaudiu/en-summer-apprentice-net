using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;
using TicketingApp.Models;

namespace TicketingApp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly JavaEndavaContext _context;

        public CustomerRepository()
        {
            _context = new JavaEndavaContext();

        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            try
            {
                var tempCustomers =  _context.Customers;
                if (tempCustomers != null)
                {
                    return tempCustomers;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
                return null;
            }

        }

        public async Task<Customer> GetById(int id)
        {
            try
            {
                var existentCustomer = await _context.Customers.Where(c => c.CustomerId == id).FirstOrDefaultAsync();
                return existentCustomer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
                return null;
            }
        }
    }
}
