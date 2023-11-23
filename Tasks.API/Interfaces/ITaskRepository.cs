using Tasks.API.Models;

namespace Tasks.API.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskGET>> GetTasks();
    }
}
