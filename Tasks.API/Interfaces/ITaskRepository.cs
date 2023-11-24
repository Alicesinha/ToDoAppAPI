using Tasks.API.Models;

namespace Tasks.API.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskGetResult>> GetTasks();
        Task<int> DeleteTask(int IdTask);
        Task<int> InsertTask(InsertTaskDto dto);
        Task<int> AlterTask(AlterTaskDto dto);
        Task<int> AlterTaskStatus(int idTask, int idStatus, DateTime? finishDate);
        Task<int> DeleteSubTask(int IdSubTask);
        Task<int> InsertSubtask(InsertSubTaskDTO dto, int IdTask);
        Task<List<SubTaskGetResult>> GetSubTasks(int IdTask);
    }
}
