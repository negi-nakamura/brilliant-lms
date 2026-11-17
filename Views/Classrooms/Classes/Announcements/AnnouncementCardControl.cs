using brilliant_lms.Theme;
using AntdUI;
using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Utilities;
using brilliant_lms.Services;

namespace brilliant_lms.Views.Classrooms.Classes.Announcements
{
    public partial class AnnouncementCardControl : UserControl
    {
        private User user;
        private AnnouncementDirectoryItem announcement;
        private AnnouncementService announcementService = new AnnouncementService();
        private bool loading;

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
            ShowLike();
        }

        private void contentLabel_SizeChanged(object sender, EventArgs e)
        {
            panel1.PerformLayout();
            Height = footerPanel.Bottom + panel1.Padding.Bottom + 2;

            if (Parent is AntdUI.GridPanel row) row.Height = Height + Margin.Vertical;
        }

        private async void likeButton_Click(object sender, EventArgs e)
        {
            if (loading) return;

            SetBusy(true);

            try
            {
                AnnouncementLikeState state = await announcementService.SetLikeAsync(user.Id, announcement.Id, !announcement.LikedByCurrentUser);
                announcement.LikedByCurrentUser = state.LikedByCurrentUser;
                announcement.LikeCount = state.LikeCount;
                ShowLike();
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Like failed", exception.Message);
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Like failed", "Unable to update your like. Please try again.");
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void ShowLike()
        {
            likeButton.Ghost = true;
            likeButton.BackHover = Color.Transparent;
            likeButton.BackActive = Color.Transparent;
            likeButton.Text = announcement.LikeCount.ToString();
            likeButton.Type = announcement.LikedByCurrentUser ? TTypeMini.Primary : TTypeMini.Default;
            likeButton.AccessibleName = announcement.LikedByCurrentUser ? "Unlike announcement" : "Like announcement";
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            likeButton.Enabled = !busy;
            likeButton.Loading = busy;
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
            footerDivider.BackColor = background;
        }
    }
}
