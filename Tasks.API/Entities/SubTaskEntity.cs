namespace Tasks.API.Entities
{
    public class SubTaskEntity
    {
        public int IdSubTask { get; set; }
        public string? Description { get; set; }
        public DateTime? CheckDate { get; set; }
        public bool Check { get; set; }
        public int IdTask { get; set; }
    }
}
