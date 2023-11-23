using Tasks.API.Entities;

namespace Tasks.API.Models
{
    public class TaskGET: TasksEntity
    {
        public required string StatusDescription { get; set; }
    }
}
