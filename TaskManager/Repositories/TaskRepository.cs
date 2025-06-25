using TaskManager.DAL;
using TaskManager.Models.DTO;

namespace TaskManager.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskDto> GetAll()
        {
            return _context.Tasks.Select(t => new TaskDto
            {
                TaskID = t.TaskId,
                TaskDescription = t.TaskDescription,
                StartDate = t.StartDate,
                ExpectedClosureDate = t.ExpectedClosureDate,
                AssignedTo = t.AssignedTo,
                CompletionStatus = t.CompletionStatus
            });
        }

        public TaskDto? GetById(int id)
        {
            var task = _context.Tasks.Find(id);
            return task == null ? null : new TaskDto
            {
                TaskID = task.TaskId,
                TaskDescription = task.TaskDescription,
                StartDate = task.StartDate,
                ExpectedClosureDate = task.ExpectedClosureDate,
                AssignedTo = task.AssignedTo,
                CompletionStatus = task.CompletionStatus
            };
        }

        public void Add(TaskDto dto)
        {
            var task = new DAL.Task
            {
                TaskDescription = dto.TaskDescription,
                StartDate = dto.StartDate,
                ExpectedClosureDate = dto.ExpectedClosureDate,
                AssignedTo = dto.AssignedTo,
                CompletionStatus = dto.CompletionStatus
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Update(TaskDto dto)
        {
            var task = _context.Tasks.Find(dto.TaskID);
            if (task == null) return;
            task.TaskDescription = dto.TaskDescription;
            task.StartDate = dto.StartDate;
            task.ExpectedClosureDate = dto.ExpectedClosureDate;
            task.AssignedTo = dto.AssignedTo;
            task.CompletionStatus = dto.CompletionStatus;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return;
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}
