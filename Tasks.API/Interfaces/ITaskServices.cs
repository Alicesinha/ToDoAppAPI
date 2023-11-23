using Tasks.API.Models;

namespace Tasks.API.Interfaces
{
    public interface ITaskServices
    {
        Task<List<TaskGET>> GetTasks();
    }
}
