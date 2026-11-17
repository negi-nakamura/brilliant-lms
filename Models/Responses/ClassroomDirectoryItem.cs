using brilliant_lms.Models.Entities;

namespace brilliant_lms.Models.Responses
{
    public class ClassroomDirectoryItem : Classroom
    {
        public DateTime JoinedAt { get; set; }
        public string TeacherFirstName { get; set; } = "";
        public string? TeacherMiddleName { get; set; }
        public string TeacherLastName { get; set; } = "";
    }
}
