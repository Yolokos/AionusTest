using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AionusTest.Models;
using AionusTest.Data;

namespace AionusTest.Controllers
{
    [Route("api/clients")]
    public class ClientsController : Controller
    {
        ClientContext context;

        public ClientsController()
        {
            context = new ClientContext();

            if(context.Clients == null && context.Tasks == null)
            {
                context.InitializeData();
            }
        }

        [HttpGet]
        public IEnumerable<ClientDisplay> Get()
        {
            return context.Clients.ToList();
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
