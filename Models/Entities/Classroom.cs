namespace brilliant_lms.Models.Entities
{
    public class Classroom
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; } = "";
        public string? Section { get; set; }
        public string? Subject { get; set; }
        public string? Room { get; set; }
        public string? Schedule { get; set; }
        public string? Level { get; set; }
        public string JoinCode { get; set; } = "";
        public bool IsArchived { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
