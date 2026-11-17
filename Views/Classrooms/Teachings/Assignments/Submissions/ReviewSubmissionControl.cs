using AntdUI;
using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using FluentValidation;

namespace brilliant_lms.Views.Classrooms.Teachings.Assignments.Submissions
{
    public partial class ReviewSubmissionControl : UserControl
    {
        private User user;
        private Assignment assignment;
        private SubmissionDirectoryItem submission;
        private SubmissionService submissionService = new SubmissionService();
        private bool loading;
        public bool saved;

        public ReviewSubmissionControl(User user, Assignment assignment, SubmissionDirectoryItem submission)
        {
            this.user = user;
            this.assignment = assignment;
            this.submission = submission;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            studentLabel.Text = TextFormatter.GetFullName(submission.StudentFirstName, submission.StudentMiddleName, submission.StudentLastName);
            statusLabel.Text = $"{submission.Status}{(submission.IsLate ? " (Late)" : "")} | {submission.Email}";
            submittedLabel.Text = submission.SubmittedAt == null ? "Not turned in" : $"Turned in: {submission.SubmittedAt:MMM dd, yyyy h:mm tt}";
            answerInput.Text = submission.AnswerText ?? "";
            attachmentButton.Visible = submission.Attachments.Count > 0;
            scoreInput.Maximum = assignment.MaxPoints;
            scoreInput.Value = submission.Score ?? 0;
            includeGrade.Checked = submission.Score != null;
            maxPointsLabel.Text = $"/ {assignment.MaxPoints:0.##} points";
            feedbackInput.Text = submission.Feedback ?? "";
            returnedLabel.Text = submission.ReturnedAt == null ? "" : $"Returned: {submission.ReturnedAt:MMM dd, yyyy h:mm tt}";
            SetBusy(false);
        }

        private void includeGrade_CheckedChanged(object sender, BoolEventArgs e)
        {
            scoreInput.Enabled = !loading && includeGrade.Checked && submission.SubmittedAt != null;
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            await SaveWorkAsync(false);
        }

        private async void returnButton_Click(object sender, EventArgs e)
        {
            await SaveWorkAsync(true);
        }

        private async Task SaveWorkAsync(bool returnWork)
        {
            if (loading) return;

            GradeSubmissionRequest request = new GradeSubmissionRequest
            {
                Score = includeGrade.Checked ? scoreInput.Value : null,
                Feedback = feedbackInput.Text.Trim(),
                ReturnWork = returnWork
            };

            SetBusy(true);
            
            try
            {
                await submissionService.GradeAsync(user.Id, assignment.Id, submission.Id, request);
                saved = true;
                FeedbackDialog.Success(FindForm()!, returnWork ? "Work returned" : "Grade saved", returnWork ? "The work has been returned to the student." : "The grade and feedback have been saved.");
                FindForm()?.Close();
            }
            catch (ValidationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Save failed", exception.Errors.First().ErrorMessage);
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Save failed", exception.Message);
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Save failed", "Unable to save student work. Please try again.");
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            FindForm()?.Close();
        }

        private void attachmentButton_Click(object sender, EventArgs e)
        {
            List<IContextMenuStripItem> items = new List<IContextMenuStripItem>();

            foreach (SubmissionAttachment attachment in submission.Attachments)
            {
                ContextMenuStripItem item = new ContextMenuStripItem(attachment.LinkUrl)
                {
                    IconSvg = "LinkOutlined",
                    Tag = attachment.LinkUrl
                };
                items.Add(item);
            }
            
            AntdUI.ContextMenuStrip.open(new(attachmentButton, HandleAttachmentSelection, items.ToArray())
            {
                Align = TAlign.Bottom,
                Radius = 0
            });
        }

        private void HandleAttachmentSelection(IContextMenuStrip item)
        {
            if (item.Tag is string link && Uri.TryCreate(link, UriKind.Absolute, out Uri? address) && (address.Scheme == Uri.UriSchemeHttp || address.Scheme == Uri.UriSchemeHttps))
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(address.AbsoluteUri) { UseShellExecute = true });
                }
                catch (Exception)
                {
                    FeedbackDialog.Error(FindForm()!, "Open failed", "Unable to open this attachment link.");
                }
            }
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            bool turnedIn = submission.SubmittedAt != null;
            includeGrade.Enabled = !busy && turnedIn;
            scoreInput.Enabled = !busy && turnedIn && includeGrade.Checked;
            feedbackInput.Enabled = !busy && turnedIn;
            saveButton.Enabled = !busy && turnedIn;
            returnButton.Enabled = !busy && turnedIn;
            closeButton.Enabled = !busy;
        }
    }
}
