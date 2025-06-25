using TaskManager.DAL;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface IDbLogger
    {
        void Log(string message, string level = "Info");
    }

    public class DbLogger : IDbLogger
    {
        private readonly TaskDbContext _context;

        public DbLogger(TaskDbContext context)
        {
            _context = context;
        }

        public void Log(string message, string level = "Info")
        {
            var log = new Log
            {
                Description = message,
                LogLevel = level,
                LogTime = DateTime.Now
            };

            _context.Logs.Add(log);
            _context.SaveChanges();
        }
    }
}
