namespace TicketingApp.Models.Dto
{
    public class CustomerDto
    {   
        public int customerId {  get; set; }

        public string name { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;
    }
}
