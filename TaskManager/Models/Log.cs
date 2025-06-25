using System;

namespace TaskManager.Models
{
    public class Log
    {
        public int LogID { get; set; }
        public string? Description { get; set; }
        public string? LogLevel { get; set; }
        public DateTime LogTime { get; set; }
    }
}
