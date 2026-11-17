using brilliant_lms.Models.Entities;

namespace brilliant_lms.Utilities
{
    public static class SubmissionStatusFormatter
    {
        public static string GetStatus(Submission submission, DateTime? dueAt, DateTime now)
        {
            if (submission.ReturnedAt != null) return "Returned";
            if (submission.Score != null) return "Graded";
            if (submission.SubmittedAt != null) return "Turned in";
            if (dueAt != null && now > dueAt) return "Missing";
            return "Assigned";
        }
    }
}
