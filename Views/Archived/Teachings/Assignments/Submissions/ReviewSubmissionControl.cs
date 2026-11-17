using AntdUI;
using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Archived.Teachings.Assignments.Submissions
{
    public partial class ReviewSubmissionControl : UserControl
    {
        private User user;
        private Assignment assignment;
        private SubmissionDirectoryItem submission;

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
            maxPointsLabel.Text = $"Grade: {submission.Score?.ToString("0.##") ?? "—"} / {assignment.MaxPoints:0.##}";
            feedbackInput.Text = submission.Feedback ?? "";
            returnedLabel.Text = submission.ReturnedAt == null ? "" : $"Returned: {submission.ReturnedAt:MMM dd, yyyy h:mm tt}";
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

    }
}
