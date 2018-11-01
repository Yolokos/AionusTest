using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AionusTest.Models;
using AionusTest.ViewModel;
using AionusTest.Data;

namespace AionusTest.Controllers
{
    [Route("api/clients")]
    public class ClientsController : Controller
    {
        ClientContext context;

        public ClientsController(ClientContext context)
        {
            this.context = context;

            if(!context.Clients.Any() && !context.Tasks.Any())
            {
                context.InitializeData();
            }
        }

        [HttpGet]
        public IEnumerable<ClientDisplay> Get()
        {
            var model = new ClientsTasksViewModel { Clients = context.Clients, Tasks = context.Tasks };

            return model.Clients;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TaskDisplay task = context.Tasks.FirstOrDefault(x => x.TaskId == id);
            if (task != null)
            {
                context.RemoveTask(id);
            }
            return Ok(task);
        }
    }
}
