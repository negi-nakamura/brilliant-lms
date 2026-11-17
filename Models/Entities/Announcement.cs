namespace brilliant_lms.Models.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        public int ClassroomId { get; set; }
        public int AuthorId { get; set; }
        public string Content { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
