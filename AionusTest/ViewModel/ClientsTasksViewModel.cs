using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AionusTest.Models;

namespace AionusTest.ViewModel
{
    public class ClientsTasksViewModel
    {
        public List<ClientDisplay> Clients { get; set; }
        public List<TaskDisplay> Tasks { get; set; }
    }
}
