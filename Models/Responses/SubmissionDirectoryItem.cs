using brilliant_lms.Models.Entities;

namespace brilliant_lms.Models.Responses
{
    public class SubmissionDirectoryItem : Submission
    {
        public string StudentFirstName { get; set; } = "";
        public string? StudentMiddleName { get; set; }
        public string StudentLastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Status { get; set; } = "";
        public bool IsLate { get; set; }
        public List<SubmissionAttachment> Attachments { get; set; } = new List<SubmissionAttachment>();
    }
}
