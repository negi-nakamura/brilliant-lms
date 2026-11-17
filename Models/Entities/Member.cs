namespace brilliant_lms.Models.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public int ClassroomId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; } = "";
        public DateTime JoinedAt { get; set; }
    }
}
