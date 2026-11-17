namespace brilliant_lms.Models.Requests
{
    public class GradeSubmissionRequest
    {
        public decimal? Score { get; set; }
        public string Feedback { get; set; } = "";
        public bool ReturnWork { get; set; }
    }
}
