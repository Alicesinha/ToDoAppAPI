using Tasks.API.Models;

namespace Tasks.API.Interfaces
{
    public interface ITaskServices
    {
        Task<List<TaskGetResult>> GetTasks();
        Task<int> DeleteTask(int idTask);
        Task<int> AlterTaskStatus(int idTask, int idStatus);
        Task<int> AlterTask(AlterTaskDto dto);
        Task<int> InsertTask(InsertTaskDto dto);
        Task<int> InsertSubTask(InsertSubTaskDTO dto, int IdTask);
        Task<int> DeleteSubTask( int idSubTask);
    }
}
