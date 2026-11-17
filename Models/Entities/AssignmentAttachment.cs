namespace brilliant_lms.Models.Entities
{
    public class AssignmentAttachment
    {
        public int AttachmentId { get; set; }
        public int AssignmentId { get; set; }
        public string FileName { get; set; } = "";
        public string LinkUrl { get; set; } = "";
        public DateTime UploadedAt { get; set; }
    }
}
