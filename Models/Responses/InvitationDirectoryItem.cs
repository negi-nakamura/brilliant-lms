using brilliant_lms.Models.Entities;

namespace brilliant_lms.Models.Responses
{
    public class InvitationDirectoryItem : ClassroomInvitation
    {
        public string InviteeFirstName { get; set; } = "";
        public string? InviteeMiddleName { get; set; }
        public string InviteeLastName { get; set; } = "";
        public string InviteeEmail { get; set; } = "";
        public string ClassroomName { get; set; } = "";
        public string InviterFirstName { get; set; } = "";
        public string? InviterMiddleName { get; set; }
        public string InviterLastName { get; set; } = "";
    }
}
