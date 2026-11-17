namespace brilliant_lms.Models.Entities
{
    public class ClassroomInvitation
    {
        public int Id { get; set; }
        public int ClassroomId { get; set; }
        public int InviterId { get; set; }
        public int InviteeId { get; set; }
        public string Role { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime? RespondedAt { get; set; }
    }
}
