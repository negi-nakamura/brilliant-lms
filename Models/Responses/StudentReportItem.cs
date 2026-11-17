namespace brilliant_lms.Models.Responses
{
    public class StudentReportItem : MemberDirectoryItem
    {
        public int AssignmentCount { get; set; }
        public int SubmittedCount { get; set; }
        public int MissingCount { get; set; }
        public int LateCount { get; set; }
        public int GradedCount { get; set; }
        public decimal? AverageGrade { get; set; }
    }
}
