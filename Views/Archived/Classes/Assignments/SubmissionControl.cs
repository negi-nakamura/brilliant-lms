using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Archived.Classes.Assignments
{
    public partial class SubmissionControl : UserControl
    {
        private User user;
        private Assignment assignment;
        private SubmissionDirectoryItem? submission;
        private SubmissionService submissionService = new SubmissionService();
        private bool loading;

        public SubmissionControl(User user, Assignment assignment)
        {
            this.user = user;
            this.assignment = assignment;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            titleLabel.Text = assignment.Title;
            statusLabel.Text = "Loading your submission...";
        }

        private async void SubmissionControl_Load(object? sender, EventArgs e)
        {
            SetBusy(true);
            try
            {
                submission = await submissionService.GetStudentSubmissionAsync(user.Id, assignment);
                if (IsDisposed) return;
                statusLabel.Text = $"{submission.Status}{(submission.IsLate ? " (Late)" : "")} | Due at: {assignment.DueAt:MMM dd, yyyy h:mm tt}";
                gradeLabel.Text = $"Grade: {submission.Score?.ToString("0.##") ?? "—"} / {assignment.MaxPoints:0.##}";
                feedbackLabel.Visible = submission.ReturnedAt != null && !string.IsNullOrWhiteSpace(submission.Feedback);
                feedbackInput.Visible = feedbackLabel.Visible;
                feedbackInput.Text = feedbackLabel.Visible ? submission.Feedback ?? "" : "";
                answerInput.Text = submission.AnswerText ?? "";
                attachmentInput.Text = string.Join(Environment.NewLine, submission.Attachments.Select(attachment => attachment.LinkUrl));
            }
            catch (InvalidOperationException exception)
            {
                if (!IsDisposed) FeedbackDialog.Error(FindForm()!, "Load failed", exception.Message);
            }
            catch (Exception)
            {
                if (!IsDisposed) FeedbackDialog.Error(FindForm()!, "Load failed", "Unable to load your submission. Please try again.");
            }
            finally
            {
                if (!IsDisposed) SetBusy(false);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            FindForm()?.Close();
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            cancelButton.Enabled = !busy;
        }
    }
}
