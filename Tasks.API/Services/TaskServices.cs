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

        public async Task<List<TaskGET>> GetTasks()
        {
            var tasks = await _taskRepository.GetTasks();
            return tasks;
        }
    }
}
