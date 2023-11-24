namespace Tasks.API.Models
{
    public class TaskGetResult
    {
        public int IdTask { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int IdStatus { get; set; }
        public required string StatusDescription { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime FinishDate { get; set; }
        public List<SubTaskGetResult>? SubTask { get; set;}
    }

    public class SubTaskGetResult
    {
        public int IdSubTask { get; set; }
        public string? Description { get; set; }
        public DateTime? CheckDate { get; set; }
        public bool Check { get; set; }
    }
}
