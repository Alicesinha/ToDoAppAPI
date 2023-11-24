using Tasks.API.Interfaces;
using Tasks.API.Models;

namespace Tasks.API.Services
{
    public class TaskServices: ITaskServices
    {
        private ITaskRepository _taskRepository;
        public TaskServices(ITaskRepository taskRepository) { 
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskGetResult>> GetTasks()
        {
            var tasks = await _taskRepository.GetTasks();

            foreach (var task in tasks)
            {
                var subTasks = await _taskRepository.GetSubTasks(task.IdTask);
                task.SubTask = subTasks;
            }
            return tasks;
        }
        public async Task<int> InsertTask(InsertTaskDto dto)
        {
            var insertedTask = await _taskRepository.InsertTask(dto);
            return insertedTask;
        }
        public async Task<int> InsertSubTask(InsertSubTaskDTO dto, int IdTask)
        {
            var insertedSubTask = await _taskRepository.InsertSubtask(dto, IdTask);
            return insertedSubTask;
        }
        public async Task<int> AlterTask(AlterTaskDto dto)
        {
            var alteredTask = await _taskRepository.AlterTask(dto);
            return alteredTask;
        }
        public async Task<int> DeleteTask(int idTask)
        {
            var deletedTask = await _taskRepository.DeleteTask(idTask);
            return deletedTask;
        }
        public async Task<int> DeleteSubTask(int idSubTask)
        {
            var deletedTask = await _taskRepository.DeleteSubTask( idSubTask);
            return deletedTask;
        }
        public async Task<int> AlterTaskStatus(int idTask, int idStatus)
        {
            DateTime? FinishDate = null;

            if (idStatus == 3)
                FinishDate = DateTime.Now;

            var task = await _taskRepository.AlterTaskStatus(idTask, idStatus, FinishDate);
            if (task <= 0) return 0;

            return task;
        }
    }
}
