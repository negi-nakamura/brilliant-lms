using brilliant_lms.Models.Entities;

namespace brilliant_lms.Models.Responses
{
    public class AssignmentDirectoryItem : Assignment
    {
        public string CreatorFirstName { get; set; } = "";
        public string? CreatorMiddleName { get; set; }
        public string CreatorLastName { get; set; } = "";
        public List<AssignmentAttachment> Attachments { get; set; } = new List<AssignmentAttachment>();
    }
}
