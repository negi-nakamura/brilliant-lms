namespace brilliant_lms.Models.Entities
{
    public class ResourceAttachment
    {
        public int AttachmentId { get; set; }
        public int ResourceId { get; set; }
        public string FileName { get; set; } = "";
        public string LinkUrl { get; set; } = "";
        public DateTime UploadedAt { get; set; }
    }
}
