
namespace brilliant_lms.Models.Entities
{
    public class SubmissionAttachment
    {
        public int AttachmentId { get; set; }
        public int SubmissionId { get; set; }
        public string FileName { get; set; } = "";
        public string LinkUrl { get; set; } = "";
        public DateTime UploadedAt { get; set; }
    }
}
