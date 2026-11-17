using brilliant_lms.Theme;
using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Archived.Teachings.Announcements
{
    public partial class AnnouncementCardControl : UserControl
    {
        private User user;
        private AnnouncementDirectoryItem announcement;

        public AnnouncementCardControl(User user, AnnouncementDirectoryItem announcement)
        {
            this.user = user;
            this.announcement = announcement;
            InitializeComponent();
            InitializeControl();
            SetBackground();
            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;
        }

        private void InitializeControl()
        {
            avatar.Text = TextFormatter.GetInitials(announcement.CreatorFirstName);
            creatorLabel.Text = TextFormatter.GetFullName(announcement.CreatorFirstName, announcement.CreatorMiddleName, announcement.CreatorLastName);
            dateLabel.Text = announcement.CreatedAt.ToString("MMM dd, yyyy h:mm tt");
            contentLabel.Text = announcement.Content;
            likesLabel.Text = announcement.LikeCount == 1 ? "1 like" : $"{announcement.LikeCount} likes";
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
            likesLabel.BackColor = background;
            footerDivider.BackColor = background;
            likeIcon.BackColor = background;
        }
    }
}
