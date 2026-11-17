using brilliant_lms.Models.Entities;

namespace brilliant_lms.Models.Responses
{
    public class StudentAssignmentReportItem : Assignment
    {
        public int StudentId { get; set; }
        public string Status { get; set; } = "";
        public DateTime? SubmittedAt { get; set; }
        public decimal? Score { get; set; }
        public bool IsLate { get; set; }
    }
}
