namespace brilliant_lms.Models.Requests
{
    public class SubmitAssignmentRequest
    {
        public string AnswerText { get; set; } = "";
        public List<string> AttachmentLinks { get; set; } = new List<string>();
    }
}
