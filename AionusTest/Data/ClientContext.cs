using System;
using System.Collections.Generic;
using System.Linq;
using AionusTest.Models;
using CsvHelper;
using System.IO;

namespace AionusTest.Data
{
    public class ClientContext
    {
        string pathClient = AppDomain.CurrentDomain.BaseDirectory + "Clients.csv";
        string pathTask = AppDomain.CurrentDomain.BaseDirectory + "Tasks.csv";

        public List<ClientDisplay> Clients { get; set; }
        public List<TaskDisplay> Tasks { get; set; }

        public ClientContext()
        {
            Clients = new List<ClientDisplay>();
            Tasks = new List<TaskDisplay>();
        }

        public void RemoveTask(int id)
        {
            TaskDisplay taskDisplay = Tasks.FirstOrDefault(p => p.ClientId == id);

            var lines = new List<string>();
            using (var file = new StreamReader(pathTask))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith(id.ToString()))
                {
                    lines.RemoveAt(i);
                    break;
                }
            }

            Tasks.Remove(taskDisplay);

            File.WriteAllLines(pathTask, lines);
        }

        public void InitializeData()
        {
            ClientDisplay clientDisplay = new ClientDisplay();
            TaskDisplay taskDisplay = new TaskDisplay();
            var csvClient = new CsvReader(new StreamReader(pathClient));
            var csvTask = new CsvReader(new StreamReader(pathTask));
            csvClient.Configuration.Delimiter = ";";
            csvTask.Configuration.Delimiter = ";";
            var ClientList = csvClient.GetRecords<Client>();
            var TaskList = csvTask.GetRecords<Task>();

            foreach (var task in TaskList)
            {
                taskDisplay.TaskId = int.Parse(task.TaskId);
                taskDisplay.TaskName = task.TaskName;
                taskDisplay.Description = task.Description;
                taskDisplay.StartTime = DateTime.Parse(task.StartTime);
                taskDisplay.EndTime = DateTime.Parse(task.EndTime);
                taskDisplay.ClientAddress = task.ClientAddress;
                taskDisplay.ClientId = int.Parse(task.ClientId);

                Tasks.Add(taskDisplay);
            }


            foreach (var client in ClientList)
            {
                clientDisplay.ClientId = int.Parse(client.ClientId);
                clientDisplay.FirstName = client.FirstName;
                clientDisplay.LastName = client.LastName;
                clientDisplay.Address = client.Address;
                clientDisplay.PhoneNumber = client.PhoneNumber;
                clientDisplay.ClientTasks = Tasks.Where(p => p.ClientId == int.Parse(client.ClientId)).ToList();

                Clients.Add(clientDisplay);
            }

            csvClient.Dispose();
            csvTask.Dispose();
        }
               
    }
}
