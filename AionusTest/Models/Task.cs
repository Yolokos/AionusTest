using System;

namespace AionusTest.Models
{
    public class Task
    {
        public string TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string ClientAddress { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string ClientId { get; set; }
    }

    public class TaskDisplay
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string ClientAddress { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int ClientId { get; set; }
    }
}
