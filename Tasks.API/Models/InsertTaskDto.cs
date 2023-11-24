namespace Tasks.API.Models
{
    public class InsertTaskDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
    public class InsertSubTaskDTO 
    { 
        public string? Description { get; set;}
        public bool Check { get; set; }
    }
}
