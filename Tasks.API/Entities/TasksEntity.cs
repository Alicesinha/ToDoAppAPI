namespace Tasks.API.Entities
{
    public class TasksEntity
    {
        public int IdTask { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int IdStatus { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
