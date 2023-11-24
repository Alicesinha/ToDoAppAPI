namespace Tasks.API.Models
{
    public class AlterTaskDto
    {
        public int idTask { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int IdStatus { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
