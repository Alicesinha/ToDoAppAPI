using Tasks.API.Models;

namespace Tasks.API.Interfaces
{
    public interface ITaskServices
    {
        Task<List<TaskGET>> GetTasks();
        Task<int> DeleteTask(int idTask);
        Task<int> AlterTaskStatus(int idTask, int idStatus);
        Task<int> AlterTask(AlterTaskDto dto);
        Task<int> InsertTask(InsertTaskDto dto);
    }
}
