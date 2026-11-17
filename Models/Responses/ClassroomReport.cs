using brilliant_lms.Models.Entities;

namespace brilliant_lms.Models.Responses
{
    public class ClassroomReport
    {
        public List<Assignment> AvailableAssignments { get; set; } = new List<Assignment>();
        public List<MemberDirectoryItem> AvailableStudents { get; set; } = new List<MemberDirectoryItem>();
        public List<AssignmentReportItem> Assignments { get; set; } = new List<AssignmentReportItem>();
        public List<StudentReportItem> Students { get; set; } = new List<StudentReportItem>();
        public List<StudentAssignmentReportItem> StudentAssignments { get; set; } = new List<StudentAssignmentReportItem>();
        public int StudentCount { get; set; }
        public int AssignmentCount { get; set; }
        public int SubmittedCount { get; set; }
        public int GradedCount { get; set; }
        public int MissingCount { get; set; }
    }
}
