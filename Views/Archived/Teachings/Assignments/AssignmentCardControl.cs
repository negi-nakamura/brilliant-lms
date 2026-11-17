using brilliant_lms.Theme;
using AntdUI;
using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Archived.Teachings.Assignments
{
    public partial class AssignmentCardControl : UserControl
    {
        private User user;
        private AssignmentDirectoryItem assignment;
        public event EventHandler<AssignmentDirectoryItem>? SubmissionsRequested;

        public AssignmentCardControl(User user, AssignmentDirectoryItem assignment)
        {
            this.user = user;
            this.assignment = assignment;
            InitializeComponent();
            InitializeControl();
            SetBackground();
            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;
        }

        private void InitializeControl()
        {
            avatar.Text = TextFormatter.GetInitials(assignment.CreatorFirstName);
            creatorLabel.Text = TextFormatter.GetFullName(assignment.CreatorFirstName, assignment.CreatorMiddleName, assignment.CreatorLastName);
            dateLabel.Text = $"Created: {assignment.CreatedAt:MMM dd, yyyy h:mm tt} | Due at: {assignment.DueAt:MMM dd, yyyy h:mm tt} | Max Points: {assignment.MaxPoints:0.##}";
            titleLabel.Text = assignment.Title;
            contentLabel.Text = assignment.Instructions ?? "";
            attachmentButton.Visible = assignment.Attachments.Count > 0;
            attachmentButton.Text = "Attachment links";
        }

        private void submissionsButton_Click(object sender, EventArgs e)
        {
            SubmissionsRequested?.Invoke(this, assignment);
        }

        private void attachmentButton_Click(object sender, EventArgs e)
        {
            List<IContextMenuStripItem> items = new List<IContextMenuStripItem>();
            foreach (AssignmentAttachment attachment in assignment.Attachments)
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
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(address.AbsoluteUri)
                    {
                        UseShellExecute = true
                    });
                }
                catch (Exception)
                {
                    FeedbackDialog.Error(FindForm()!, "Open failed", "Unable to open the attachment link in your browser.");
                }
            }
        }

        private void contentLabel_SizeChanged(object sender, EventArgs e)
        {
            panel1.PerformLayout();
            Height = footerPanel.Bottom + panel1.Padding.Bottom + 2;

            if (Parent is AntdUI.GridPanel row) row.Height = Height + Margin.Vertical;
        }

        private void ThemeManager_ThemeChanged(object? sender, EventArgs e)
        {
            SetBackground();
        }

        private void SetBackground()
        {
            Color background = AntdUI.Style.Db.BgElevated;
            BackColor = background;
            panel1.Back = background;
            panel1.BackColor = background;
            headerPanel.Back = background;
            headerPanel.BackColor = background;
            footerPanel.Back = background;
            footerPanel.BackColor = background;
            creatorLabel.BackColor = background;
            dateLabel.BackColor = background;
            contentLabel.BackColor = background;
            titleLabel.BackColor = background;
            footerDivider.BackColor = background;
        }
    }
}
