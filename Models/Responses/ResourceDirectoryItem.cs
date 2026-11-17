using brilliant_lms.Models.Entities;

namespace brilliant_lms.Models.Responses
{
    public class ResourceDirectoryItem : Resource
    {
        public string CreatorFirstName { get; set; } = "";
        public string? CreatorMiddleName { get; set; }
        public string CreatorLastName { get; set; } = "";
        public List<ResourceAttachment> Attachments { get; set; } = new List<ResourceAttachment>();
    }
}
