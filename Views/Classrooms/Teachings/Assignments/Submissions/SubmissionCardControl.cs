using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Classrooms.Teachings.Assignments.Submissions
{
    public partial class SubmissionCardControl : UserControl
    {
        private Assignment assignment;
        private SubmissionDirectoryItem submission;
        public event EventHandler<SubmissionDirectoryItem>? ReviewRequested;

        public SubmissionCardControl(Assignment assignment, SubmissionDirectoryItem submission)
        {
            this.assignment = assignment;
            this.submission = submission;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            avatar.Text = TextFormatter.GetInitials(submission.StudentFirstName);
            nameLabel.Text = TextFormatter.GetFullName(submission.StudentFirstName, submission.StudentMiddleName, submission.StudentLastName);
            dateLabel.Text = submission.SubmittedAt == null ? "Not turned in" : $"Turned in: {submission.SubmittedAt:MMM dd, yyyy h:mm tt}";
            statusLabel.Text = submission.Status + (submission.IsLate ? " (Late)" : "");
            scoreLabel.Text = $"{submission.Score?.ToString("0.##") ?? "—"} / {assignment.MaxPoints:0.##}";
        }

        private void SubmissionCardControl_Click(object sender, EventArgs e)
        {
            ReviewRequested?.Invoke(this, submission);
        }
    }
}
