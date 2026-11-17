namespace brilliant_lms.Models.Requests
{
    public class CreateAssignmentRequest
    {
        public string Title { get; set; } = "";
        public string Instructions { get; set; } = "";
        public DateTime? DueAt { get; set; }
        public decimal MaxPoints { get; set; } = 100;
        public List<string> AttachmentLinks { get; set; } = new List<string>();
    }
}
