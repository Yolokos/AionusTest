using System.Collections.Generic;

namespace AionusTest.Models
{
    public class Client
    {
        public string ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ClientDisplay
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

       // public List<TaskDisplay> ClientTasks { get; set; }
    }
}
