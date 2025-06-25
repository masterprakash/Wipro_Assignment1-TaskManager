using TaskManager.Models.DTO;

namespace TaskManager.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskDto> GetAll();
        TaskDto? GetById(int id);
        void Add(TaskDto task);
        void Update(TaskDto task);
        void Delete(int id);
    }
}
