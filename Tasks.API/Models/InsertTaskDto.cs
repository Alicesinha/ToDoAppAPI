namespace Tasks.API.Models
{
    public class InsertTaskDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
