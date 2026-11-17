using brilliant_lms.Models.Entities;

namespace brilliant_lms.Models.Responses
{
    public class AnnouncementDirectoryItem : Announcement
    {
        public string CreatorFirstName { get; set; } = "";
        public string? CreatorMiddleName { get; set; }
        public string CreatorLastName { get; set; } = "";
        public bool LikedByCurrentUser { get; set; }
        public int LikeCount { get; set; }
    }
}
