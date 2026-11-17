namespace brilliant_lms.Models.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public int ClassroomId { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; } = "";
        public string? Instructions { get; set; }
        public DateTime? DueAt { get; set; }
        public decimal MaxPoints { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
