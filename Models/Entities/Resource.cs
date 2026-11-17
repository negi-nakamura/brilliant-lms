namespace brilliant_lms.Models.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        public int ClassroomId { get; set; }
        public int UploaderId { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public string LinkUrl { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
