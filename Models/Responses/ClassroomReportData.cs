using brilliant_lms.Models.Entities;

namespace brilliant_lms.Models.Responses
{
    public class ClassroomReportData
    {
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
        public List<MemberDirectoryItem> Students { get; set; } = new List<MemberDirectoryItem>();
        public List<Submission> Submissions { get; set; } = new List<Submission>();
    }
}
