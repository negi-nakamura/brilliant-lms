namespace brilliant_lms.Models.Requests
{
    public class ReportFilterRequest
    {
        public int? AssignmentId { get; set; }
        public int? StudentId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
