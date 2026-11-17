using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using FluentValidation;

namespace brilliant_lms.Views.Classrooms.Classes.Assignments
{
    public partial class SubmitAssignmentControl : UserControl
    {
        private User user;
        private Assignment assignment;
        private SubmissionDirectoryItem? submission;
        private SubmissionService submissionService = new SubmissionService();
        private bool loading;

        public SubmitAssignmentControl(User user, Assignment assignment)
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
            submitButton.Enabled = false;
            answerInput.Enabled = false;
            attachmentInput.Enabled = false;
        }

        private async void SubmitAssignmentControl_Load(object? sender, EventArgs e)
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
                submitButton.Text = submission.ReturnedAt == null ? "Turn in" : "Resubmit";
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

        private async void submitButton_Click(object sender, EventArgs e)
        {
            if (loading) return;
            SubmitAssignmentRequest request = new SubmitAssignmentRequest
            {
                AnswerText = answerInput.Text.Trim(),
                AttachmentLinks = attachmentInput.Text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList()
            };
            SetBusy(true);
            try
            {
                await submissionService.SubmitAsync(user.Id, assignment.Id, request);
                FeedbackDialog.Success(FindForm()!, "Assignment submitted", "Your work has been turned in successfully.");
                FindForm()?.Close();
            }
            catch (ValidationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Submit failed", exception.Errors.First().ErrorMessage);
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Submit failed", exception.Message);
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Submit failed", "Unable to submit your assignment. Please try again.");
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
            bool editable = submission != null && (submission.SubmittedAt == null || submission.ReturnedAt != null);
            answerInput.Enabled = !busy && editable;
            attachmentInput.Enabled = !busy && editable;
            submitButton.Enabled = !busy && editable;
            cancelButton.Enabled = !busy;
        }
    }
}
