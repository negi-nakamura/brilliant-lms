namespace brilliant_lms.Models.Entities
{
    public class Submission
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public string? AnswerText { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public decimal? Score { get; set; }
        public string? Feedback { get; set; }
        public int? GradedById { get; set; }
        public DateTime? ReturnedAt { get; set; }
        public DateTime? GradedAt { get; set; }
    }
}
