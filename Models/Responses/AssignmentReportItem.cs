using brilliant_lms.Models.Entities;

namespace brilliant_lms.Models.Responses
{
    public class AssignmentReportItem : Assignment
    {
        public int StudentCount { get; set; }
        public int SubmittedCount { get; set; }
        public int MissingCount { get; set; }
        public int GradedCount { get; set; }
        public decimal? AverageScore { get; set; }
    }
}
