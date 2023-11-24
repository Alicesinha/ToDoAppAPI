using Tasks.API.Models;

namespace Tasks.API.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskGET>> GetTasks();
        Task<int> DeleteTask(int IdTask);
        Task<int> InsertTask(InsertTaskDto dto);
        Task<int> AlterTask(AlterTaskDto dto);
        Task<int> AlterTaskStatus(int idTask, int idStatus, DateTime? finishDate);
    }
}
